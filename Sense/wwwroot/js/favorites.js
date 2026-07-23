(function () {
    var STORAGE_KEY = 'senseFavorites';

    function getFavorites() {
        try {
            var raw = localStorage.getItem(STORAGE_KEY);
            return raw ? JSON.parse(raw) : [];
        } catch (e) {
            return [];
        }
    }

    function saveFavorites(ids) {
        localStorage.setItem(STORAGE_KEY, JSON.stringify(ids));
    }

    function isFavorite(id) {
        return getFavorites().indexOf(String(id)) !== -1;
    }

    function toggleFavorite(id) {
        id = String(id);
        var favorites = getFavorites();
        var index = favorites.indexOf(id);
        if (index === -1) {
            favorites.push(id);
        } else {
            favorites.splice(index, 1);
        }
        saveFavorites(favorites);
        return favorites;
    }

    function updateFavIcons() {
        var favorites = getFavorites();
        document.querySelectorAll('.fav-btn').forEach(function (btn) {
            var id = btn.getAttribute('data-product-id');
            var icon = btn.querySelector('i');
            var active = favorites.indexOf(id) !== -1;
            btn.classList.toggle('active', active);
            if (icon) {
                icon.classList.toggle('bi-heart', !active);
                icon.classList.toggle('bi-heart-fill', active);
            }
        });
    }

    function updateWishlistCount() {
        var badge = document.getElementById('wishlistCount');
        if (badge) {
            badge.textContent = getFavorites().length;
        }
    }

    function refresh() {
        updateFavIcons();
        updateWishlistCount();
    }

    document.addEventListener('click', function (e) {
        var btn = e.target.closest && e.target.closest('.fav-btn');
        if (!btn) return;
        e.preventDefault();
        var id = btn.getAttribute('data-product-id');
        toggleFavorite(id);
        refresh();
        document.dispatchEvent(new CustomEvent('favorites:changed', { detail: { productId: id } }));
    });

    document.addEventListener('DOMContentLoaded', refresh);

    window.SenseFavorites = {
        getFavorites: getFavorites,
        isFavorite: isFavorite,
        toggleFavorite: toggleFavorite,
        refresh: refresh
    };
})();
