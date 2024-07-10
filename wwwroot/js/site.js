// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const navEl = document.querySelector('.navbar');

window.addEventListener('scroll', () => {
    if (window.scrollY > 56) {
        navEl.classList.add('nb-scroll');
        navEl.classList.remove('bg-transparent');
        
    }
    if (window.scrollY < 56) {
        navEl.classList.add('bg-traansparent');
        navEl.classList.remove('nb-scroll');
    }

})
