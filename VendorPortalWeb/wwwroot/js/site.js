// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', function () {
    const sections = document.querySelectorAll('#main-content > section');
    const navLinks = document.querySelectorAll('.navbar-nav .nav-link');

    navLinks.forEach(link => {
        link.addEventListener('click', function (event) {
            event.preventDefault();
            const targetId = this.getAttribute('href').substring(1);

            // Hide all sections
            sections.forEach(section => section.style.display = 'none');

            // Show target section
            document.getElementById(targetId).style.display = 'block';

            // Update active link
            navLinks.forEach(link => link.classList.remove('active'));
            this.classList.add('active');
        });
    });

    // Show the default section
    document.querySelector('#orders').style.display = 'block';
});
document.addEventListener('DOMContentLoaded', function () {
    const counters = document.querySelectorAll('.counter-value');

    counters.forEach(counter => {
        const countTo = parseInt(counter.getAttribute('data-count'));
        let count = 0;
        const speed = 200; // The speed of the counting effect

        const updateCount = () => {
            if (count < countTo) {
                count += Math.ceil(countTo / speed);
                counter.textContent = count;
                setTimeout(updateCount, 1);
            } else {
                counter.textContent = countTo; // Ensure it ends at the exact count
            }
        };

        updateCount();
    });
});