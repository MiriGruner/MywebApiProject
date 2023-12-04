


async function filterProducts() {
   // if(sessionStorage.getItem(""))
    const minPrice = document.getElementById("minPrice").value;
    const maxPrice = document.getElementById("maxPrice").value;
    const nameSearch = document.getElementById("nameSearch").value;
    let url = `/api/Product?desc=${nameSearch}&minPrice=${minPrice}&maxPrice=${maxPrice}`
    let checkedCategories = [];
    const allCategories = document.querySelectorAll(".opt");
   
    for (var i = 0; i < allCategories.length; i++) {
        if (allCategories[i].checked)
            checkedCategories.push(allCategories[i].value)

    }
    for (let i = 0; i < checkedCategories.length; i++) {
        url += `&categoryIds=${checkedCategories[i]}`
    }
    const res = await fetch(url);
    const data = await res.json();
    return data;
}

async function showProducts() {
    const data = await filterProducts();
    c = data.length
    document.getElementById("counter").innerHTML=c
    document.getElementById("PoductList").replaceChildren([]);
    for ( let i = 0; i < data.length; i++) {
        drowProducts(data[i])
    }

}
 function drowProducts(product) {
    var prod = document.getElementById("temp-card");
    var cln = prod.content.cloneNode(true);
     cln.querySelector("h1").innerText = product.productName;
     cln.querySelector("img").src = "../images/" + product.image;
     cln.querySelector(".price").innerText = product.price +"¤";
     cln.querySelector(".description").innerText = product.description;
     cln.querySelector("button").addEventListener('click', () => { addToCart(product) });
     document.getElementById("PoductList").appendChild(cln);
}
const cart = []
var count = 0;
var c = 0;
function addToCart(prod) {
    count++;
    document.getElementById("ItemsCountText").innerHTML=count
    cart.push(prod);
    sessionStorage.setItem("product", JSON.stringify(cart));
}

async function getCategories() {
    const res = await fetch(`/api/Category`);
    const data = await res.json();
    return data;

}

async function drowCategory() {
    const data = await getCategories();
    for (let i = 0; i < data.length; i++) {
        var prod = document.getElementById("temp-category");
        var cln = prod.content.cloneNode(true);
        cln.querySelector(".OptionName").innerText = data[i].name;
        cln.querySelector(".opt").value = data[i].categoryId;
        document.getElementById("categoryList").appendChild(cln);  
    }
}


