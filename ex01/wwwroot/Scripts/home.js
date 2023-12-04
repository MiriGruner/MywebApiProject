const register = async () => {

    var email = document.getElementById("userNameRegister").value
    var password = document.getElementById("passwordRegister").value

    var firstName = document.getElementById("firstName").value
    var lastName = document.getElementById("lastName").value
    var user = { email, password, firstName, lastName }
    try {
        const res = await fetch('api/User', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
           
        });
       
        const dataPost = await res.json();
        alert(`user ${dataPost.userId} created sucssesfuly. please login now`);
    }
    catch (er) {
       alert(er.message)
    }
}
var users;

const login = async () => {
    try {
        
        var email = document.getElementById("userNameLogin").value
        var password = document.getElementById("passwordLogin").value
        var user = { email, password }
        const res = await fetch('api/User/login', {
            method: 'POST',
            headers: {
            'Content-Type': 'application/json'
        },
            body: JSON.stringify(user)
        });
   
        if (!res.ok) {
            throw new Error("error!!!")
        }
        else {
            var data = await res.json()
            sessionStorage.setItem("user", JSON.stringify(data))

            window.location.href = "./update.html"

        }
    }
    catch (er) {
        alert(er.message)
    }
    


}
const checkCode = async () => {
    var strength = {
        0: "Worst",
        1: "Bad",
        2: "Weak",
        3: "Good",
        4: "Strong"
    }
    var meter = document.getElementById('password-strength-meter');
    var text = document.getElementById('password-strength-text');
    const Code = document.getElementById("passwordRegister").value;
    const res = await fetch('api/User/check', {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(Code)
    })
    if (!res.ok)
        throw new Error("error in adding your details to our site")
    const data = await res.json();
    if (data <= 2) alert("your password is weak!! try again")
    meter.value = data;

    if (Code !== "") {
        text.innerHTML = "Strength: " + strength[data.score];
    } else {
        text.innerHTML = "";
    }

}
