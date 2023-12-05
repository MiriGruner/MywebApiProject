
let User = JSON.parse(sessionStorage.getItem("user"))
const loadPage = () => {
    welcome.innerHTML = `hello to ${User.email}`
    const userName = document.getElementById("userName")
    userName.value = User.email
    const password = document.getElementById("password")
    password.value = User.password

    const firstName = document.getElementById("firstName")
    firstName.value = User.firstName

    const lastName= document.getElementById("lastName")
    lastName.value = User.lastName
}



const update = async () => {
    User = JSON.parse(sessionStorage.getItem("user"))
    var userId = User.userId
    var email = document.getElementById("userName").value
    var password = document.getElementById("password").value
    var firstName = document.getElementById("firstName").value
    var lastName = document.getElementById("lastName").value
    var User = { userId, email, password, firstName, lastName }
    try {
        const res = await fetch(`api/user/${userId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(User)

        });
        if (!res.ok)
         throw new Error("error")

        alert(userId + "updated sucssesfuly")
    } catch(er) {
        alert("error:"+er)
    }
}