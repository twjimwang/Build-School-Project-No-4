let timer = document.getElementById('counter')
let dateTimeNow = new Date();
let timeNow = dateTimeNow.getTime();
let minSet = 15;
let expireTime = new Date(dateTimeNow.setMinutes(dateTimeNow.getMinutes() + minSet)).getTime();
let timeLeft = (expireTime - timeNow)/1000;
let min, sec;
min = Math.floor(timeLeft / 60);
sec = 0;
let setTime = setInterval(countdown, 1000)
function countdown(){
    sec--
    timeLeft--;
    if (sec<0 && min > 0){
        sec = 59;
        min--
        timer.innerText= `${min}m ${sec}s`;
    } else if (sec > 0 && min > 0) {
        timer.innerText= `${min}m ${sec}s`;
    } else if (sec == 0 && min == 0) {
        timer.innerText= '0s';
        clearInterval(setTime)
    } else {
        timer.innerText= `${sec}s`;
    }
}

