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

function createAccount() {
    var email = document.getElementById("email").value;
    var password1 = document.getElementById("password1").value;
    var password2 = document.getElementById("password2").value; 
    var errorLabel = document.getElementById("errorLabel");

    if (email != "" && password1 != "" && password2 != "" && password1 == password2) {
        firebase.auth().createUserWithEmailAndPassword(email, password1)
            .then((userCredential) => {

                // save uid and username
                var currentUser = firebase.auth().currentUser.uid;
                var username = email.split('@');

                setTimeout(function () {
                    firebase.auth().onAuthStateChanged(function (user) {
                        if (user) {
                            window.location.href = '/Home';
                        }
                    });
                }, 850);

            })
            .catch((error) => {
                var errorCode = error.code;
                var errorMessage = error.message;
                alert(errorMessage);
            });
    } else {
        errorLabel.style.display = "block";
        errorLabel.innerHTML = "All fields are required and passwords must match."
    }
    
}