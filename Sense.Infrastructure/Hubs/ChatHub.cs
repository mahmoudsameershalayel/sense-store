using Sense.Application;
using Sense.Domain;
using Sense.Domain.DBEntities;
using Sense.Domain.Enums;
using Sense.Application.DTOs.ChatMessaageDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace Sense.Infrastructure.Hubs
{

    public class ChatHub : Hub
    {
        private readonly UserManager<ApplicationUserTbl> _userManager;
        private readonly IRepositoryManager _repositoryManager;
        private readonly SenseDbContext _context;
        public ChatHub(UserManager<ApplicationUserTbl> userManager , IRepositoryManager repositoryManager , SenseDbContext context)
        {
            _userManager = userManager;
            _repositoryManager = repositoryManager;
            _context = context;
        }
        public async Task SendMessageToTechSupport(string message)
        {
            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(userId);

            // Check if user is already in a session
            var existingSession = await _context.ChatSessionTbls
    .FirstOrDefaultAsync(x => x.UserId == userId);

            // Save message in DB
            var saveMessage = new ChatMessageTbl();
            

            if (existingSession != null)
            {
                // Send to the tech support currently handling this session
                var receiverId = existingSession?.TechSupportId;
                var connections = await _repositoryManager.Connection.GetConnectionsByUserIdAsync(receiverId);
                var connectionIds = connections.Select(x => x.ConnectionId).ToList();
                await Clients.Clients(connectionIds).SendAsync("ReceiveUserMessage", new
                {
                    SenderId = userId,
                    Message = message,
                    Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
                });
                // Save message in DB
                saveMessage = new ChatMessageTbl()
                {
                    SenderId = userId,
                    ReceiverId = receiverId, 
                    Message = message,
                    Timestamp = DateTime.UtcNow
                };
            }
            else
            {
                // Send to all tech support users
                var techSupports = await _userManager.Users
                    .Where(x => x.UserType == UserType.TechSupport)
                    .ToListAsync();

                foreach (var tech in techSupports)
                {
                    var connections = await _repositoryManager.Connection.GetConnectionsByUserIdAsync(tech.Id);
                    var connectionIds = connections.Select(x => x.ConnectionId).ToList();
                    await Clients.Clients(connectionIds).SendAsync("ReceiveUserMessage", new
                    {
                        SenderId = userId,
                        Message = message,
                        Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
                    });
                    await Clients.Clients(connectionIds).SendAsync("NewUserStartedChat", new
                    {
                        UserId = userId,
                        Username = user.ApplicationUser.UserName, // fetch from DB
                        ImageURL = user.ApplicationUser.ImageURL ?? "/assets/img/user.png"
                    });
                }
                // Save message in DB
                saveMessage = new ChatMessageTbl()
                {
                    SenderId = userId,
                    ReceiverId = null,
                    Message = message,
                    Timestamp = DateTime.UtcNow
                };
            }

            
            await _context.ChatMessageTbls.AddAsync(saveMessage);
            await _context.SaveChangesAsync();
        }

        public async Task SendMessageToTechSupportById(string userId , string message)
        {
            var user = await _repositoryManager.ApplicationUser.GetCustomerByApplicationUserId(userId);

            // Check if user is already in a session
            var existingSession = await _context.ChatSessionTbls
    .FirstOrDefaultAsync(x => x.UserId == userId);

            // Save message in DB
            var saveMessage = new ChatMessageTbl();


            if (existingSession != null)
            {
                // Send to the tech support currently handling this session
                var receiverId = existingSession?.TechSupportId;
                var connections = await _repositoryManager.Connection.GetConnectionsByUserIdAsync(receiverId);
                var connectionIds = connections.Select(x => x.ConnectionId).ToList();
                await Clients.Clients(connectionIds).SendAsync("ReceiveUserMessage", new
                {
                    SenderId = userId,
                    Message = message,
                    Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
                });
                // Save message in DB
                saveMessage = new ChatMessageTbl()
                {
                    SenderId = userId,
                    ReceiverId = receiverId,
                    Message = message,
                    Timestamp = DateTime.UtcNow
                };
            }
            else
            {
                // Send to all tech support users
                var techSupports = await _userManager.Users
                    .Where(x => x.UserType == UserType.TechSupport)
                    .ToListAsync();

                foreach (var tech in techSupports)
                {
                    var connections = await _repositoryManager.Connection.GetConnectionsByUserIdAsync(tech.Id);
                    var connectionIds = connections.Select(x => x.ConnectionId).ToList();
                    await Clients.Clients(connectionIds).SendAsync("ReceiveUserMessage", new
                    {
                        SenderId = userId,
                        Message = message,
                        Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
                    });
                    await Clients.Clients(connectionIds).SendAsync("NewUserStartedChat", new
                    {
                        UserId = userId,
                        Username = user.ApplicationUser.UserName, // fetch from DB
                        ImageURL = user.ApplicationUser.ImageURL ?? "/assets/img/user.png"
                    });
                }
                // Save message in DB
                saveMessage = new ChatMessageTbl()
                {
                    SenderId = userId,
                    ReceiverId = null,
                    Message = message,
                    Timestamp = DateTime.UtcNow
                };
            }


            await _context.ChatMessageTbls.AddAsync(saveMessage);
            await _context.SaveChangesAsync();
        }

        public async Task SendMessageToUser(string userId, string message)
        {
            var senderId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // Check if session exists
            var existingSession = await _context.ChatSessionTbls
      .FirstOrDefaultAsync(x => x.UserId == userId);

            if (existingSession == null)
            {
                // Create new session
                var newSession = new ChatSessionTbl
                {
                    UserId = userId,
                    TechSupportId = senderId,
                    IsClosed = false
                };
                await _context.ChatSessionTbls.AddAsync(newSession);
                await _context.SaveChangesAsync();  
                await _repositoryManager.SaveAsync();
            }

            // Send message to the user
            var connections = await _repositoryManager.Connection.GetConnectionsByUserIdAsync(userId);
            var connectionIds = connections.Select(x => x.ConnectionId).ToList();
            await Clients.Clients(connectionIds).SendAsync("ReceiveSupportMessage", new
            {
                Message = message,
                Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
            });

            // Save message
            var saveMessage = new ChatMessageTbl()
            {
                SenderId = senderId,
                ReceiverId = userId,
                Message = message,
                Timestamp = DateTime.UtcNow
            };
            _repositoryManager.ChatMessage.CreateChatMessage(saveMessage);
            await _repositoryManager.SaveAsync();
        }
        public async Task<List<ChatMessageDto>> GetPreviousMessages()
        {
            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var messages = await _context.ChatMessageTbls
                .Where(m => m.SenderId == userId || m.ReceiverId == userId)
                .OrderBy(m => m.Timestamp)
                .Distinct()
                .ToListAsync();

            var result = messages.Select(m => new ChatMessageDto
            {
                Message = m.Message,
                Timestamp = m.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"),
                IsSender = m.SenderId.Equals(userId)
            }).Distinct().ToList();

            return result;
        }
        public async Task<List<ChatMessageDto>> GetPreviousMessagesById(string userId)
        {

            var messages = await _context.ChatMessageTbls
                .Where(m => m.SenderId == userId || m.ReceiverId == userId)
                .OrderBy(m => m.Timestamp)
                .Distinct()
                .ToListAsync();

            var result = messages.Select(m => new ChatMessageDto
            {
                Message = m.Message,
                Timestamp = m.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"),
                IsSender = m.SenderId.Equals(userId)
            }).Distinct().ToList();

            return result;
        }

        public async Task<List<ChatMessageDto>> GetPreviousMessagesForUser(string otherUserId)
        {
            var currentUserId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var messages = await _context.ChatMessageTbls
                .Where(m =>
                    (m.SenderId == currentUserId && m.ReceiverId == otherUserId) ||
                    (m.SenderId == otherUserId && m.ReceiverId == currentUserId) || (m.SenderId == otherUserId && m.ReceiverId == null)
                )
                .OrderBy(m => m.Timestamp)
                .Distinct()
                .ToListAsync();

            var result = messages.Select(m => new ChatMessageDto
            {
                Message = m.Message,
                Timestamp = m.Timestamp.ToString("yyyy-MM-dd HH:mm:ss"),
                IsSender = m.SenderId == currentUserId
            }).Distinct().ToList();

            return result;
        }
        public override async Task OnConnectedAsync()
        {
            var userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var connectionId = Context.ConnectionId;
            if (userId != null)
            {
                var connection = new ConnectionTbl() { UserId = userId, ConnectionId = connectionId };
                _repositoryManager.Connection.CreateConnection(connection);
                await _repositoryManager.SaveAsync();
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var connectionId = Context.ConnectionId;
            var connection = await _repositoryManager.Connection.GetConnectionByConnectionId(connectionId);
            if (connection != null)
            {
                _repositoryManager.Connection.DeleteConnection(connection);
                await _repositoryManager.SaveAsync();
            }

            await base.OnDisconnectedAsync(exception);
        }
      

    }
}
