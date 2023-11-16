function showList(event,songID) {
    var listContainer = document.getElementById('list-container');

    // Get button coordinates
    var button = event.currentTarget; // The button that was clicked
    var buttonRect = button.getBoundingClientRect();

    // Get the current scroll position
    var scrollX = window.scrollX || window.pageXOffset;
    var scrollY = window.scrollY || window.pageYOffset;

    // Set list position based on button coordinates and scroll position
    listContainer.style.left = buttonRect.left + scrollX + 'px';
    listContainer.style.top = buttonRect.bottom + scrollY + 'px'; // Adjust as needed

    // Display the list
    listContainer.style.display = 'block';
}

// Hide the list when clicking outside of the list and add-playlist icon
document.addEventListener('click', function (event,songID) {
    var listContainer = document.getElementById('list-container');
    var playlistIcon = document.querySelectorAll('.fa-plus-square-o');
    var form = document.getElementById('userPlaylist');

    var isClickedOn = false;

    // Check if the click event target is one of the add-playlist icon
    playlistIcon.forEach(function (icon) {
        if (event.target === icon) {
            isClickedOn = true;
        }
    });

    // Hide the list container if not clicked on the list or song divs
    if (!isClickedOn && event.target !== listContainer && event.target !== playlistIcon && !listContainer.contains(event.target) && !form.contains(event.target)) {
        listContainer.style.display = 'none';
    }
});


