
// Function that activates when page is fully loaded
document.addEventListener("DOMContentLoaded", function () {
    // Image sizing (due to the fact that we only have one img that swaps between different ones)
    let toothlessImg = document.getElementById("image1");
    toothlessImg.width = 600;
    toothlessImg.height = 450;

    // Music 
    let backgroundMusic = document.getElementById("backgroundMusic");
    backgroundMusic.play();

    // Buttons Actions
    let changeImg = document.getElementById("changeImage");
    let changeTitle = document.getElementById("changeTitle");
    let changeParagraph = document.getElementById("changeParagraph");
    changeImg.addEventListener("click", changeToothlessMood);
    changeTitle.addEventListener("click", changeToothlessTitle);
    changeParagraph.addEventListener("click", changeToothlessText);
});

// When you declare events that are able to work when page is loaded you dont need to declare itself in the function
function changeToothlessMood() {
    let toothlessImg = document.getElementById("image1");

    // Hides elements
    let toothlessTitle= document.getElementsByTagName('h1')[0];
    let toothlessText = document.getElementsByTagName('p')[0];
    toothlessTitle.style.color = "white";
    toothlessText.style.color = "white";

    // Applies changes
    if (toothlessImg.alt === "image1") {
        toothlessImg.src = "img/Toothless2.gif";
        toothlessImg.alt = "image2";
        document.getElementById("backgroundMusic").play();
    } 
    else if (toothlessImg.alt === "image2") {
        toothlessImg.src = "img/Toothless3.gif";
        toothlessImg.alt = "image3";
        document.getElementById("backgroundMusic").pause();
    } 
    else {
        toothlessImg.src = "img/Toothless1.gif";
        toothlessImg.alt = "image1";
        document.getElementById("backgroundMusic").pause();
    }
}

// Changes H1 text when button is pressed, but it depends the image that is currently on display
function changeToothlessTitle() {
    let toothlessImg = document.getElementById("image1");

    // Show elements
    let toothlessTitle= document.getElementsByTagName('h1')[0];
    toothlessTitle.style.color = "black";

    // Applies changes
    if (toothlessImg.alt === "image1") {
        toothlessTitle.innerText = "A lil hungry Toothless";
    } 
    else if (toothlessImg.alt === "image2") {
        toothlessTitle.innerText = "Party dancer Toothless";
    }
    else {
        toothlessTitle.innerText = "Omega LUL Toothless";
    }
}

// Changes paragraph text when button is pressed, but it depends the image that is currently on display
function changeToothlessText() {
    let toothlessImg = document.getElementById("image1");

    // Show elements
    let toothlessText = document.getElementsByTagName('p')[0];
    toothlessText.style.color = "black";

    // Applies changes
    if (toothlessImg.alt === "image1") {
        toothlessText.innerText = "C'mon bring him some juicy food to eat, look how cute he is.";
    } 
    else if (toothlessImg.alt === "image2") {
        toothlessText.innerText = "Nobody can stop him, his dance is so catchy.";
    }
    else {
        toothlessText.innerText = "OMG!!!! this exercise deserves a 10.";
    }
}