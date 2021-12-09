var firebaseConfig = {
    apiKey: "AIzaSyCv_m5dvh4R0HGuYqKYTDXhDrX4mB2kZtw",
    authDomain: "planmytrip-80f3d.firebaseapp.com",
    projectId: "planmytrip-80f3d",
    storageBucket: "planmytrip-80f3d.appspot.com",
    messagingSenderId: "493337833060",
    appId: "1:493337833060:web:a10170db3dc61ada32b971",
    measurementId: "G-1MVYMEX1R1"
};

// Initialize Firebase
firebase.initializeApp(firebaseConfig);
firebase.analytics();

var userName = document.getElementById("userName");

function onLoad() {

    firebase.auth().onAuthStateChanged(function (user) {
        if (user) {
            var userEmail = user.email;
            userName.innerHTML = userEmail.substr(0, userEmail.indexOf('@'));

            //Hide all elements for non existing users
            document.querySelectorAll('.userNotLoggedIn').forEach(function (element) {
                element.classList.add('hideElement');
            });

            document.querySelectorAll('.userLoggedIn').forEach(function (element) {
                element.classList.remove('hideElement');
            });
                
        }
        else {
            //Hide all elements for existing users
            document.querySelectorAll('.userLoggedIn').forEach(function (element) {
                element.classList.add('hideElement');
            });
                
            document.querySelectorAll('.userNotLoggedIn').forEach(function (element) {
                element.classList.remove('hideElement');
            });     
        }
    });
}

function showHistory() {

    var username = document.getElementById("userName").innerHTML;
    var url = "/home/History?username=" + username;
    window.location.href = url;
}

function logOut() {
    firebase.auth().signOut().then(() => {
        window.location.href = '/Home/HomePage';
    }).catch((error) => {
        alert(error);
    });
}