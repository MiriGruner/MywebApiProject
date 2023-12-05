const register = async () => {

    var email = document.getElementById("userNameRegister").value
    var password = document.getElementById("passwordRegister").value

    var firstName = document.getElementById("firstName").value
    var lastName = document.getElementById("lastName").value
    var user = { email, password, firstName, lastName }
    var em = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!em.test(email)) {
        alert("your email adress is not valid")
        return;
    }
    if (firstName.length <3) {
        alert("first name is too short")
        return;
    }

    if (lastName.length <2) {
        alert("last name is too short")
        return;
    }

    if (lastName.length > 20) {
        alert("last name is too long")
        return;
    }

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
      console.log(er.message)
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
        console.log(er.message)
    }
    


}
const checkCode = async () => {
    var meter = document.getElementById('password-strength-meter');
    var text = document.getElementById('password-strength-text');
    const Code = document.getElementById("passwordRegister").value;
    try {
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
    }
    catch (er) {
        console.log("error",er)
    }
    if (data <= 2)
        alert("your password is weak!! try again")
    meter.value = data;

}
