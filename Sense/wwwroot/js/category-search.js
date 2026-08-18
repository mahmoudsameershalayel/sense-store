(function () {
    "use strict";

    function normalizeArabic(value) {
        return (value || "")
            .toLocaleLowerCase("ar")
            .normalize("NFKD")
            .replace(/[\u064B-\u065F\u0670\u0640]/g, "")
            .replace(/[أإآٱ]/g, "ا")
            .replace(/ى/g, "ي")
            .replace(/ة/g, "ه")
            .trim();
    }

    document.querySelectorAll("[data-category-search]").forEach(function (form) {
        var input = form.querySelector(".sf-category-search__input");
        var panel = form.querySelector(".sf-category-search__suggestions");
        var emptyState = form.querySelector("[data-category-search-empty]");
        var suggestions = Array.from(form.querySelectorAll("[data-category-suggestion]"));

        if (!input || !panel) {
            return;
        }

        suggestions.forEach(function (suggestion) {
            suggestion.dataset.normalizedName = normalizeArabic(suggestion.dataset.categoryName);
        });

        function closeSuggestions() {
            panel.hidden = true;
            input.setAttribute("aria-expanded", "false");
        }

        function updateSuggestions() {
            var query = normalizeArabic(input.value);
            var visibleCount = 0;

            suggestions.forEach(function (suggestion) {
                var matches = query.length > 0 && suggestion.dataset.normalizedName.includes(query);
                var shouldShow = matches && visibleCount < 7;
                suggestion.hidden = !shouldShow;
                if (shouldShow) {
                    visibleCount++;
                }
            });

            if (!query) {
                closeSuggestions();
                return;
            }

            if (emptyState) {
                emptyState.hidden = visibleCount > 0;
            }

            panel.hidden = false;
            input.setAttribute("aria-expanded", "true");
        }

        function getVisibleSuggestions() {
            return suggestions.filter(function (suggestion) {
                return !suggestion.hidden;
            });
        }

        input.addEventListener("input", updateSuggestions);
        input.addEventListener("focus", function () {
            if (input.value.trim()) {
                updateSuggestions();
            }
        });

        input.addEventListener("keydown", function (event) {
            var visibleSuggestions = getVisibleSuggestions();

            if (event.key === "ArrowDown" && visibleSuggestions.length) {
                event.preventDefault();
                visibleSuggestions[0].focus();
            } else if (event.key === "Escape") {
                closeSuggestions();
            }
        });

        suggestions.forEach(function (suggestion, index) {
            suggestion.addEventListener("keydown", function (event) {
                var visibleSuggestions = getVisibleSuggestions();
                var currentIndex = visibleSuggestions.indexOf(suggestion);

                if (event.key === "ArrowDown") {
                    event.preventDefault();
                    (visibleSuggestions[currentIndex + 1] || visibleSuggestions[0]).focus();
                } else if (event.key === "ArrowUp") {
                    event.preventDefault();
                    if (currentIndex <= 0) {
                        input.focus();
                    } else {
                        visibleSuggestions[currentIndex - 1].focus();
                    }
                } else if (event.key === "Escape") {
                    closeSuggestions();
                    input.focus();
                }
            });
        });

        form.addEventListener("submit", function (event) {
            event.preventDefault();
            var firstMatch = getVisibleSuggestions()[0];
            if (firstMatch) {
                window.location.assign(firstMatch.href);
            } else {
                updateSuggestions();
                input.focus();
            }
        });

        document.addEventListener("click", function (event) {
            if (!form.contains(event.target)) {
                closeSuggestions();
            }
        });
    });
})();
