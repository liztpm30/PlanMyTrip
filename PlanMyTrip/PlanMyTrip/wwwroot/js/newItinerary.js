$(document).ready(function () {

    if (firebase.auth().currentUser == undefined || firebase.auth().currentUser == undefined) {
        document.getElementById('submitButton').disabled = true;
    }

    firebase.auth().onAuthStateChanged(function (user) {
        if (user) {
            document.querySelectorAll('#submitButton').forEach(function (element) {
                element.disabled = false;
            });
        }
        else {
            document.querySelectorAll('#submitButton').forEach(function (element) {
                element.disabled = true;
            });
        }
    });
});