
function login() {
    var email = document.getElementById("email").value;
    var password1 = document.getElementById("password1").value;
    var errorLabel = document.getElementById("errorLabel");

    if (email != "" && password1 != "") {
        firebase.auth().signInWithEmailAndPassword(email, password1).then((userCredential) => {

            var currentUser = firebase.auth().currentUser;

            window.location.href = '/Home/HomePage';
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