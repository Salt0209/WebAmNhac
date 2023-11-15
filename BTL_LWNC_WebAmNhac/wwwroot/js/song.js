function redirectToDetails(id) {
    // Redirect to the desired URL with the specific ID
    window.location.href = '/Songs/Details/?id=' + id;
}

function playInNewTab(id) {
    // Redirect to the desired URL with the specific ID
    window.open('/Songs/Details/?id=' + id, '_blank');
}