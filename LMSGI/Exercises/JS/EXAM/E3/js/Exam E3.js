let changer = document.getElementById("changeButton")
changer.addEventListener("click", startCounting);
var stop = document.getElementById("stopButton");
stop.addEventListener("click", stopCounting);
var seconds = 0;
var changerClicked = false;
var stopClicked = false;
var interval;

function startCounting() {
    if (!changerClicked) {
        interval = setInterval(updateSeconds, 3000);
        startClicked = true;
        stopClicked = false;
    }
}

function stopCounting() {
    changerClicked = false;
    if (!stopClicked) {
        clearInterval(interval);
        stopClicked = true;
    }
}

function updateSeconds() {
    let changed = false;
    let element = document.getElementById("image1");
    if(seconds === 3)
    {
        if(!changed) {
        element.src = "previousToothless.gif";
        element.img = "image2"
        }
        else
        {
            element.src = "Toothless.gif";
            element.img = "image1"
        }
    }
    else {
        if (stopClicked) {
            seconds = seconds;
        } 
        else {
            seconds++;
        }
    }
}

function changesImg() {
    startCounting()
}

changer.addEventListener("click", function() {
    changesImg()
})

stop.addEventListener("click", function() {
    stopCounting()
})


