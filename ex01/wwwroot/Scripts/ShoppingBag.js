let products = JSON.parse(sessionStorage.getItem("product"))
let count = 0;
function drowProducts(product) {

    var prod = document.getElementById("temp-row");
    var cln = prod.content.cloneNode(true);
    count = 0;
    for (var i = 0; i < products.length; i++) {
        count+=products[i].price
    }
    document.getElementById("totalAmount").innerHTML=count
    document.getElementById("itemCount").innerHTML=products.length
    cln.querySelector("img").src = "images/" + product.image;
    cln.querySelector(".price").innerText = product.price + "¤";
    cln.querySelector(".descriptionColumn").innerText = product.description;
    cln.querySelector(".totalColumn").addEventListener('click', () => { deleteProd(product) });
    document.getElementById("myItem").appendChild(cln);
}

function getProducts() {
    products = JSON.parse(sessionStorage.getItem("product"))
    for (let i = 0; i < products.length; i++) {
        drowProducts(products[i])
    }
}


function deleteProd(prod) {
    products = products.filter(p => p != prod)
    sessionStorage.setItem("product", JSON.stringify(products))
    document.getElementById("myItem").replaceChildren([])
    getProducts()
}
async function placeOrder() {
    if (sessionStorage.getItem("user") == null) { 
    alert("please login")
        window.location.href = "./home.html"
    }
    var order = {
        orderDate: new Date(),
        orderSum: count,
        userId: JSON.parse(sessionStorage.getItem("user")).userId,
        orderItems: products
    };

    try {
       

        const response = await fetch("api/order", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(order)
        })
        if (!response.ok)
            throw new Error("error")
       
            const res = await response.json();
            alert(`order number ${res.orderId} was recived sucssesfully`)
            sessionStorage.setItem("product", JSON.stringify(""))
            window.location.href ="ShoppingBag.html"
           
        
    }
    catch (err) {
        console.log("error",err)

    }

}