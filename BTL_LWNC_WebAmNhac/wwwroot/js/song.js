/*Chức năng tới trang phát nhạc*/
function redirectToDetails(id) {
	// Redirect to the desired URL with the specific ID
	window.location.href = '/Songs/Details/?id=' + id;
}
/*Chức năng tới trang phát nhạc ở tab mới*/
function playInNewTab(id) {
	// Redirect to the desired URL with the specific ID
	window.open('/Songs/Details/?id=' + id, '_blank');
}