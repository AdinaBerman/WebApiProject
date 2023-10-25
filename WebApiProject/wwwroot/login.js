//const showRregister () => {
//    const reg = document.getElementById("visibilityRegister")
//    reg.
//}
const login = async () => {

    try {
        const UserName = document.getElementById("username").value
        const Password = document.getElementById("password").value
        const res = await fetch(`api/Users?UserName=${UserName}&Password=${Password}`,
            {
                method: 'GET',
                headers: { 'Content-Type': 'application/json' },
            })

        if (!res.ok)
            window.alert("userName or password are not valid")
        else {
            const user = await res.json()
            sessionStorage.setItem("user", JSON.stringify(user))
            window.location.href = "update.html"
        }

    } catch (e) {
        window.alert("userName or password are not valid " + e);
    }
}

const register = async () => {
    const user = {
        UserName: document.getElementById("userNameRegister").value,
        Password: document.getElementById("passwordRegister").value,
        firstName: document.getElementById("FirstName").value,
        lastName: document.getElementById("LastName").value
    }

    const checkIfStrong = await checkStrongPassword()

    if (checkIfStrong != 1) {
        alert("Please enter strong password!")
    }

    try {
        const res = await fetch('api/Users',
            {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(user)

            })
        if (!res.ok)
            alert("Sorry, we couldn't add you to our site, Try again")
        else {
            const data = await res.json()
            alert(`user ${data.userName} registered succfully`)
        }
    }

    catch (err) {
        alert("something not good... :(")
        console.log(err)
    }
}

const checkStrongPassword = async () => {

    const strongPass = document.getElementById("passwordRegister").value
    const progressValue = document.getElementById("progressValue")

    try {
        const res = await fetch('api/Users/checkStrongPassword',
            {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(strongPass)

            })
        if (!res.ok)
            alert("Your password ist strong, enter a new one")

        const score = await res.json()
        progressValue.value = score;

        if (score > 2) {
            alert("Strong password!! :)")
            return 0;
        }
        else {
             alert("Easy password... :(")
            return 1;
        }

    }
    catch (err) {
        alert(err)
    }
}

