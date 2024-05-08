var seconds = 0;
var startClicked = false;
var stopClicked = false;
var interval;

var start = document.getElementById("startButton");
start.addEventListener("click", startCounting);

var stop = document.getElementById("stopButton");
stop.addEventListener("click", stopCounting);

var textTimer = document.getElementById("textArea");
textTimer.textContent = updateTextArea();

function kBOOM() {
    var videoElement = document.createElement('video');
    videoElement.src = 'video/kBOOM.mp4';

    document.body.innerHTML = '';
    document.body.appendChild(videoElement);
    
    videoElement.autoplay = true;
    document.getElementsByTagName("video").style.display = "block";
    videoElement.width = '100%';
    videoElement.height = '100%';
}

function startCounting() {
    if (!startClicked) {
        interval = setInterval(updateSeconds, 1000);
        startClicked = true;
        stopClicked = false;
        start.innerHTML = 'Counting...';
        stop.innerHTML = 'Stop Counting';
    }
}

function stopCounting() {
    startClicked = false;
    if (!stopClicked) {
        clearInterval(interval);
        stopClicked = true;
        start.innerHTML = 'Resume Counting';
        stop.innerHTML = 'Paused...';
    }
}

function updateSeconds() {
    if(seconds === 50)
    {
        let lbl = document.getElementsByTagName("label")[0];
        lbl.innerHTML = 'Say goodbye';
    }

    if (seconds === 60) {
        seconds = 0;
        startClicked = false;
        clearInterval(interval);
        kBOOM();
    }
    else {
        if (stopClicked) {
            seconds = seconds;
        } 
        else {
            seconds++;
        }
    }
    textTimer.textContent = updateTextArea();
}

function updateTextArea() {
    return seconds;
}
