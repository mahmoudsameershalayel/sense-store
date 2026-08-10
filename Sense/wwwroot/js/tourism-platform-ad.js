(function () {
    "use strict";

    var popup = document.getElementById("tourismPlatformAd");
    if (!popup) {
        return;
    }

    var storageKey = "sense-tourism-platform-ad-seen";
    var dialog = popup.querySelector(".tourism-ad__dialog");
    var closeButtons = popup.querySelectorAll("[data-tourism-ad-close]");
    var previousFocus = null;
    var previousOverflow = "";

    function hasBeenSeen() {
        try {
            return window.sessionStorage.getItem(storageKey) === "true";
        } catch (_) {
            return false;
        }
    }

    function rememberAsSeen() {
        try {
            window.sessionStorage.setItem(storageKey, "true");
        } catch (_) {
            // The popup still works when browser storage is unavailable.
        }
    }

    function openPopup() {
        if (hasBeenSeen()) {
            return;
        }

        rememberAsSeen();
        previousFocus = document.activeElement;
        previousOverflow = document.body.style.overflow;
        document.body.style.overflow = "hidden";
        popup.hidden = false;
        popup.setAttribute("aria-hidden", "false");

        window.requestAnimationFrame(function () {
            popup.classList.add("tourism-ad--visible");
            dialog.focus({ preventScroll: true });
        });
    }

    function closePopup() {
        if (popup.hidden) {
            return;
        }

        popup.classList.remove("tourism-ad--visible");
        popup.setAttribute("aria-hidden", "true");
        document.body.style.overflow = previousOverflow;

        window.setTimeout(function () {
            popup.hidden = true;
        }, 220);

        if (previousFocus && typeof previousFocus.focus === "function") {
            previousFocus.focus({ preventScroll: true });
        }
    }

    closeButtons.forEach(function (button) {
        button.addEventListener("click", closePopup);
    });

    document.addEventListener("keydown", function (event) {
        if (event.key === "Escape" && !popup.hidden) {
            closePopup();
        }
    });

    openPopup();
})();
