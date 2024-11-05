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
    //document.querySelector('#orders').style.display = 'block';
});
$(document).ready(function () {
    // Initialize DataTable with server-side processing
    var table = $('#ordersTable').DataTable({
        "processing": true,
        "serverSide": true,
        "lengthMenu": [50], // Allow user to select page sizes
        "ajax": {
            url: "https://localhost:7079/orders/LoadOrders",
            type: "GET",
            dataSrc: function (json) {
                if (json.data.length === 0) {
                    alert('No data found');
                }
                return json.data;
            }
        },
        "columns": [
            { data: 'orderNumber' },
            { data: 'orderRef' },
            {
                data: 'customerName',
                render: function (data) {
                    return data.trim().replace(/- *$/g, "");
                }
            },
            {
                data: 'dxCreatedDate',
                render: function (data) {
                    return new Date(data).toLocaleDateString();
                }
            },
            {
                data: 'dxStatus',
                render: function (data) {
                    return `<span class="badge ${data === "Invoiced" ? "bg-success-custom" : data === "Canceld" ? "bg-error" : "bg-warning"}">${data}</span>`;
                }
            }
        ],
        "dom": '<"top"f>rt<"bottom"ip><"clear">',
        "pagingType": "full_numbers"
    });
});
$(document).ready(function () {
    $('.counter-value').each(function () {
        var $this = $(this);
        var countTo = $this.attr('data-count');

        $({ countNum: $this.text() }).animate({
            countNum: countTo
        },
            {
                duration: 2000,
                easing: 'swing',
                step: function () {
                    $this.text(Math.floor(this.countNum));
                },
                complete: function () {
                    $this.text(this.countNum);
                }
            });
    });
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