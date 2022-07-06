function SubmitItemToMongo(){
    let itemVal = document.getElementById("ItemInput").value;
    let xhr = new XMLHttpRequest();
    xhr.open("POST", `https://localhost:7049/ShoppingList/SubmitItem?itemName=${itemVal}`, false);
    xhr.setRequestHeader("Accept", "text/plain");
    xhr.setRequestHeader("Content-Type", "text/plain");
    xhr.send();
}
function DisplayAllItems(){
    let xhr = new XMLHttpRequest();
    xhr.open("GET", "https://localhost:7049/ShoppingList/DisplayAllRecords", false);
    xhr.setRequestHeader("Accept", "application/json");
    xhr.send();
    let allItemsArr = JSON.parse(xhr.response);
    for (item of allItemsArr)
    {
        let textTag = document.createElement("p");
        let text = document.createTextNode(item);
        textTag.appendChild(text);
        let disSection = document.getElementById("DisplaySection");
        disSection.innerHTML += "<br>";
        disSection.appendChild(textTag);
    }
}
