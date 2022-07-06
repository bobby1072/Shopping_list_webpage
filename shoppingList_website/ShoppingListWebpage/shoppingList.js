function DisplayItem(item){
    const disSection = document.getElementById("DisplaySection");
    let textTag = document.createElement("p");
    let text = document.createTextNode(item);
    textTag.appendChild(text);
    disSection.appendChild(textTag);
}
function SubmitItemToMongo(){
    document.getElementById("DisplaySection").replaceChildren();
    let itemVal = document.getElementById("ItemInput").value;
    let xhr = new XMLHttpRequest();
    xhr.open("POST", `https://localhost:7049/ShoppingList/SubmitItem?itemName=${itemVal}`, false);
    xhr.setRequestHeader("Accept", "text/plain");
    xhr.setRequestHeader("Content-Type", "text/plain");
    xhr.send();
    if (xhr.responseText == "Submitted Correctly")
    {
        DisplayItem("Item submitted.");
    }
}
function DisplayAllItems(){
    document.getElementById("DisplaySection").replaceChildren();
    let xhr = new XMLHttpRequest();
    xhr.open("GET", "https://localhost:7049/ShoppingList/DisplayAllRecords", false);
    xhr.setRequestHeader("Accept", "application/json");
    xhr.send();
    let allItemsArr = JSON.parse(xhr.response);
    for (item of allItemsArr)
    {
        DisplayItem(item);
    }
}
