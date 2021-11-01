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

var title = document.getElementById("title");

function onLoad() {

    firebase.auth().onAuthStateChanged(function (user) {
        if (user) {
            title.innerHTML = "User is Logged in..";
        } else {
            window.location.href = './Home/HomePage';
        }
    });
}

function logOut() {
    firebase.auth().signOut().then(() => {
        window.location.href = './HomePage';
    }).catch((error) => {
        alert(error);
    });
}