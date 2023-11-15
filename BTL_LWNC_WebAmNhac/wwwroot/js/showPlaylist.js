function showList(event) {
    var listContainer = document.getElementById('list-container');

    // Get cursor coordinates
    var x = event.pageX;
    var y = event.pageY;

    // Set list position
    listContainer.style.left = x + 'px';
    listContainer.style.top = y + 'px';

    // Display the list
    listContainer.style.display = 'block';
}

// Hide the list when clicking outside of the list and add-playlist icon
document.addEventListener('click', function (event) {
    var listContainer = document.getElementById('list-container');
    var playlistIcon = document.querySelectorAll('.fa-plus-square-o');
    var form = document.getElementById('playlistForm');

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

function savePlaylist() {
    var form = document.getElementById('playlistForm');
    var selectedItems = [];

    // Iterate over the checkboxes to find the selected items
    form.querySelectorAll('input[type="checkbox"]:checked').forEach(function (checkbox) {
        selectedItems.push(checkbox.name);
    });

    // You can do something with the selected items here
    console.log('Selected items:', selectedItems);

    // For demonstration, hide the list after saving
    var listContainer = document.getElementById('list-container');
    listContainer.style.display = 'none';
}
