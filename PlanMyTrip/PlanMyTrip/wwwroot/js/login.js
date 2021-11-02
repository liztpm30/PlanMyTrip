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

function login() {
    var email = document.getElementById("email").value;
    var password1 = document.getElementById("password1").value;
    var errorLabel = document.getElementById("errorLabel");

    if (email != "" && password1 != "") {
        firebase.auth().signInWithEmailAndPassword(email, password1).then((userCredential) => {
            window.location.href = '/Home';
        }).catch((error) => {
            var errorCode = error.code;
            var errorMessage = error.message;

            errorLabel.style.display = "block";
            errorLabel.innerHTML = "Incorrect email or password entered. <br /> Please try again .."; 
        });
    } else {
        alert("All fields are required.")
    }
}