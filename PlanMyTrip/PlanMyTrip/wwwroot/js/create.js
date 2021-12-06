
const httpReq = new XMLHttpRequest();

function createAccount() {
    var email = document.getElementById("email").value;
    var password1 = document.getElementById("password1").value;
    var password2 = document.getElementById("password2").value; 
    var errorLabel = document.getElementById("errorLabel");

    if (email != "" && password1 != "" && password2 != "" && password1 == password2) {
        firebase.auth().createUserWithEmailAndPassword(email, password1)
            .then(function () {

                currentUser = firebase.auth().currentUser;
                currentUser.sendEmailVerification();
            })
            .then(function () {

                var uid = currentUser.uid;
                var username = currentUser.email.substr(0, email.indexOf('@'));

                //save uid and username
                httpReq.open('post', '/home/CreateUserRecord', true);
                httpReq.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                httpReq.send('username=' + username + '&uid=' + uid);

                setTimeout(function () {
                    firebase.auth().onAuthStateChanged(function (user) {
                        if (user) {
                            window.location.href = '/Home/HomePage';
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