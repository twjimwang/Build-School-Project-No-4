

let html = document.queryCommandValue('html')
let logbtn = document.querySelector('#loginmodal')
let signbtn = document.querySelector('#signupmodal')
let modalbtn = document.querySelectorAll('.modalbutton');
let modalbtnclose = document.querySelector('.modal-btn-close');
let maillog = document.querySelector('.maillog');
let phonelog = document.querySelector('.phonelog');
let mobileicon = document.querySelector('.fa-mobile');
let mailicon = document.querySelector('.fa-envelope');
let logsignBtn = document.querySelector('#loginbutton');
//let signupBtn = document.querySelector('.signupbutton');
let msgicon = document.querySelectorAll('.message-icon-bk');
let msgiconCl = document.querySelectorAll('.message-icon-cl');
let msgListTitle = document.querySelector('#message-list-title');
let msgClose = document.querySelector('.msg-close');
let msgdropdown = document.querySelector('.dropdown-menu');

let logsigntab = document.querySelectorAll('.logsign-tab');
let logsigntitle = document.querySelector('.logsign-title');
let modalfooter = document.querySelector('.modalfooter');
let modalfooterP = document.querySelector('.modalfooter>p');
let passinput = document.querySelectorAll('#myinput');
let passshow = document.querySelectorAll('.passwordshow');


let msgroom = document.querySelector('#dropdown-message');
let searchbar = document.querySelector('.search input');
let statusbar = document.querySelector('.statusbar');
let statuslistbtn = document.querySelectorAll('.aside-Menu .dropdown-menu button');

let email = document.querySelector(".emailinput");
/*let password = document.querySelector(".passwordinput");*/
let logsignmodalbtn = document.querySelector('.logsign-modal-button');
window.onload = function () {
    //login / signup modal
    modalbtn.forEach((btn, idx) => {
        logsigntab[idx].classList.remove('logsign-purple-border');

        btn.addEventListener('click', function (event) {

            //初始化modal打開樣式
            logsigntab[idx].classList.add('logsign-purple-border');
            logsigntitle.innerHTML = idx === 0 ? "Log in and experience ePal services for free" : "Sign in and experience ePal services for free";
            modalfooter.style.display = idx === 0 ? 'flex' : 'none';
            logsignBtn.innerHTML = idx === 0 ? "Log In" : "Sign Up";
            maillog.style.display = 'block';

            logsigntab.forEach((item, index) => {
                //modal裡面按下不同tab，執行各自的purple border
                item.addEventListener('click', function (event) {
                    item.classList.remove('logsign-purple-border');
                    logsigntab.forEach(e => {
                        e.classList.remove('logsign-purple-border');
                        logsigntitle.innerHTML = index === 0 ? "Log in and experience ePal services for free" : "Sign up and experience ePal services for free";
                        modalfooter.style.display = index === 0 ? 'flex' : 'none';
                        logsignBtn.innerHTML = index === 0 ? "Log In" : "Sign Up";
                    })
                    event.srcElement.classList.add('logsign-purple-border');
                })
                //modal關閉後清除purple border
                modalbtnclose.addEventListener('click', function (event) {
                    item.classList.remove('logsign-purple-border');
                })
            })
        })
    })
    $('#myModal').modal({ backdrop: 'static', keyboard: false });
let mailerror = document.getElementById('email-error');
let passerror = document.getElementById('myinput-error');
let valerror = document.querySelectorAll(".field-validation-error");



window.onload = function () {

    if (localStorage.getItem("loginEmail") == null) {
        logsignmodalbtn.style.display = "block";
    } else {
        logsignmodalbtn.style.display = "none";
    }
    //signupBtn.addEventListener('click', function () {
    //    localStorage.setItem("signupEmail", email.value);
    //})

    //let loginData = {
    //    email: email,
    //    password: password
    //}
    logsignBtn.addEventListener('click', function () {
/*        if (localStorage.getItem("login") == null) {*/
        localStorage.setItem("loginEmail", email.value);
/*        }*/
        //else {
        //    loginarray = JSON.parse(localStorage.getItem("login"));    
        //}
    })





    let navItems = document.querySelectorAll('.navItem');
    navItems.forEach(ele => {
        ele.classList.remove('purple-text-border');
        ele.addEventListener('click', function (event) {
            navItems.forEach(e => {
                e.classList.remove('purple-text-border');
            })
            event.srcElement.classList.add('purple-text-border');
        })
    })



    //login / signup modal
    modalbtn.forEach((btn, idx) => {
        logsigntab[idx].classList.remove('logsign-purple-border');

        btn.addEventListener('click', function (event) {

            //初始化modal打開樣式
            logsigntab[idx].classList.add('logsign-purple-border');
            logsigntitle.innerHTML = idx === 0 ? "Log in and experience ePal services for free" : "Sign in and experience ePal services for free";
            //modalfooter.style.display = idx === 0 ? 'flex' : 'none';
            modalfooterP.innerHTML = idx === 0 ? 'Or log in with' : 'Or sign up with';
            logsignBtn.innerHTML = idx === 0 ? "Log In" : "Sign Up";
            maillog.style.display = 'block';

            //登入驗證errormsg清除
            document.querySelectorAll(".field-validation-error").forEach(item => {
                item.innerText = "";
            })


            logsigntab.forEach((item, index) => {
                //modal裡面按下不同tab，執行各自的purple border
                item.addEventListener('click', function (event) {
                    // maillog.style.display = 'block';

                    //登入驗證errormsg清除
                    document.querySelectorAll(".field-validation-error").forEach(item => {
                        item.innerText = "";
                    })


                    item.classList.remove('logsign-purple-border');
                    logsigntab.forEach(e => {
                        e.classList.remove('logsign-purple-border');
                        logsigntitle.innerHTML = index === 0 ? "Log in and experience ePal services for free" : "Sign up and experience ePal services for free";
                        //modalfooter.style.display = index === 0 ? 'flex' : 'none';
                        modalfooterP.innerHTML = index === 0 ? 'Or log in with' : 'Or sign up with';
                        logsignBtn.innerHTML = index === 0 ? "Log In" : "Sign Up";
                    })
                    event.srcElement.classList.add('logsign-purple-border');
                })
                //modal關閉後清除purple border
                modalbtnclose.addEventListener('click', function (event) {
                    item.classList.remove('logsign-purple-border');
                })
            })
        })
    })
    $('#myModal').modal({ backdrop: 'static', keyboard: false });

}





////modal password hide/show
//function Password() {
//    passinput.forEach((input, idx) => {
//        if (input.type === "password") {
//            input.type = "text";
//            passshow[idx].value = "hide";
//        } else {
//            input.type = "password";
//            passshow[idx].value = "show";
//        }
//    })
//}

//modal password hide/show
passinput.forEach((input, idx) => {

    passshow[idx].addEventListener('click', function () {

        if (input.type === "password") {
            input.type = "text";
            passshow[idx].value = "hide";
        } else {
            input.type = "password";
            passshow[idx].value = "show";
        }
    })

})




//dropdown點選查詢不關閉下拉框
$("body").on('click', '[data-stopPropagation]', function (e) {
    e.stopPropagation();
});



//dropdown-message-ul icon replace
msgicon.forEach((icon, idx) => {
    icon.addEventListener('click', function (event) {
        msgicon[0].src = "/Assets/images/layout/message1.png";
        msgicon[1].src = "/Assets/images/layout/message2.png";
        msgicon[2].src = "/Assets/images/layout/message3.png";

        switch (idx) {
            case 0:
                msgListTitle.innerHTML = "Order Messages";
                icon.src = "/Assets/images/layout/message11.png";
                break;
            case 1:
                msgListTitle.innerHTML = "Social Messages";
                icon.src = "/Assets/images/layout/message21.png";
                break;
            case 2:
                msgListTitle.innerHTML = "System Messages";
                icon.src = "/Assets/images/layout/message31.png";
                break;
            default:
                break;
        }
    })
})


//personal info.  open/close  
function PersonalOpen() {
    document.querySelector(".aside-Menu").style.width = "400px";
    document.querySelector(".aside-Menu").style.right = "0%";
    document.querySelector(".aside-Menu").style.zIndex = "10";
}
function PersonalClose() {
    document.querySelector(".aside-Menu").style.right = "-100%";
}



//chatroom  open/close
function MsgRoomOpen() {
    document.querySelector(".chat-container").style.display = "block";
}
function MsgRoomClose() {
    document.querySelector(".chat-container").style.display = "none";
}



//gotop
$(function () {
    $('#gotop').click(function () {
        event.preventDefault();
        $('html,body').animate({ scrollTop: 0 }, 'fast');
        return false;
    });

    $(window).scroll(function () {
        if ($(this).scrollTop() > 200) {
            $('#gotop').fadeIn();
        } else {
            $('#gotop').fadeOut();
        }
    });
});



function changeLong() {
    searchbar.style.width = '250px';
}

function changeShort() {
    searchbar.style.width = '100px';
}




//online/offline change
statuslistbtn.forEach((stabtn, idx) => {
    // statusbar.innerHTML = `<img src="online.png" alt="">ONLINE`;
    stabtn.addEventListener('click', function () {
        statusbar.innerHTML = stabtn.innerHTML;

    })
})



    //< button type = "button" class="btn btn-secondary" data - bs - dismiss="modal" id = "loginbutton" disabled = "true" >
    //    Log In
    //                        </button >
//let mailinput = document.querySelectorAll('.emailinput');
//let passinput = document.querySelectorAll('.passwordinput');

//logsignBtn.forEach((btn,idx), function () {

//    if (mailinput[idx] != "" && passinput[idx] != "")
//    {
//        logsignBtn[idx].disabled = false;
//    }
//})


//$(function () {

//    $("#logsignform").validate({
//        rules: {
//            email: {
//                required: true,
//                email: true
//            },
//            myinput: "required"
//        },
//        messages: {
//            email: {
//                required: "Please enter your Email",
//                email: "Email format is not true"
//            },
//            myinput: "Please enter your password"
//        },
//        //submitHandler: function (logsignform) {
//        //    form.submit();
//        //}
//    });
//});


    //(function () {
    //    'use strict'

    //    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    //    var forms = document.querySelectorAll('.needs-validation')

    //    // Loop over them and prevent submission
    //    Array.prototype.slice.call(forms)
    //        .forEach(function (form) {
    //            form.addEventListener('submit', function (event) {
    //                if (!form.checkValidity()) {
    //                    event.preventDefault()
    //                    event.stopPropagation()
    //                }

    //                form.classList.add('was-validated')
    //            }, false)
    //        })
    //})()