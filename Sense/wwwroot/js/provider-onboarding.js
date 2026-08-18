(() => {
    const form = document.querySelector('[data-category-form]');
    if (!form) return;

    const search = form.querySelector('[data-category-search]');
    const options = Array.from(form.querySelectorAll('.po-category-option'));
    const nextButton = form.querySelector('[data-category-next]');
    const emptyState = form.querySelector('[data-category-empty]');

    const normalize = value => (value || '')
        .toLocaleLowerCase('ar')
        .replace(/[أإآ]/g, 'ا')
        .replace(/ة/g, 'ه')
        .trim();

    form.addEventListener('change', event => {
        if (event.target.matches('input[name="categoryKey"]')) {
            nextButton.disabled = false;
        }
    });

    search?.addEventListener('input', () => {
        const query = normalize(search.value);
        let visibleCount = 0;

        options.forEach(option => {
            const visible = !query || normalize(option.dataset.categoryName).includes(query);
            option.hidden = !visible;
            if (visible) visibleCount++;
        });

        if (emptyState) emptyState.hidden = visibleCount !== 0;
    });
})();
