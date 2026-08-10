(function () {
    "use strict";

    const editorSelector = ".js-business-description-editor";

    function initializeEditors() {
        if (typeof window.ClassicEditor === "undefined") {
            return;
        }

        document.querySelectorAll(editorSelector).forEach(function (textarea) {
            if (textarea.dataset.editorInitialized === "true") {
                return;
            }

            textarea.dataset.editorInitialized = "true";

            window.ClassicEditor.create(textarea, {
                language: "ar",
                placeholder: textarea.dataset.editorPlaceholder || textarea.getAttribute("placeholder") || "",
                toolbar: {
                    items: [
                        "undo",
                        "redo",
                        "|",
                        "heading",
                        "|",
                        "bold",
                        "italic",
                        "link",
                        "|",
                        "bulletedList",
                        "numberedList",
                        "blockQuote"
                    ],
                    shouldNotGroupWhenFull: false
                },
                heading: {
                    options: [
                        { model: "paragraph", title: "فقرة", class: "ck-heading_paragraph" },
                        { model: "heading2", view: "h2", title: "عنوان رئيسي", class: "ck-heading_heading2" },
                        { model: "heading3", view: "h3", title: "عنوان فرعي", class: "ck-heading_heading3" }
                    ]
                },
                link: {
                    addTargetToExternalLinks: true,
                    defaultProtocol: "https://"
                }
            }).then(function (editor) {
                const editingRoot = editor.editing.view.document.getRoot();
                editor.editing.view.change(function (writer) {
                    writer.setAttribute("dir", "rtl", editingRoot);
                });

                const editableElement = editor.ui.view.editable.element;
                if (editableElement) {
                    editableElement.setAttribute(
                        "aria-label",
                        textarea.dataset.editorLabel || "محرر وصف النشاط التجاري"
                    );
                }

                function syncTextarea() {
                    textarea.value = editor.getData();
                }

                editor.model.document.on("change:data", syncTextarea);

                const form = textarea.closest("form");
                if (form) {
                    form.addEventListener("submit", syncTextarea);
                }
            }).catch(function (error) {
                textarea.dataset.editorInitialized = "false";
                console.error("Could not initialize the business description editor.", error);
            });
        });
    }

    if (document.readyState === "loading") {
        document.addEventListener("DOMContentLoaded", initializeEditors, { once: true });
    } else {
        initializeEditors();
    }
})();
