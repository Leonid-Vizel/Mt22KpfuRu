﻿let currentYear = 0;
function Toggle(year, program, thesis, winners) {
    if (year == currentYear) return;
    let years = document.getElementsByClassName("page-item");
    for (let i = 0; i < years.length; i++) {
        if (years[i].getAttribute("id") == year && !years[i].classList.contains("active")) {
            years[i].classList.add("active");
        }
        else if (years[i].getAttribute("id") != year && years[i].classList.contains("active")) {
            years[i].classList.remove("active");
        }
    }
    buttons = [
        document.getElementById('program-button'),
        document.getElementById('thesis-button'),
        document.getElementById('winners-button')
    ];
    buttons[0].setAttribute('href', `/docs/history/${year}/Program.pdf`);
    buttons[1].setAttribute('href', `/docs/history/${year}/Thesis.pdf`);
    buttons[2].setAttribute('href', `/docs/history/${year}/Winners.pdf`);
    if (program != 'True') {
        document.getElementById('program-block').setAttribute('hidden', 'hidden');
    }
    else {
        document.getElementById('program-block').removeAttribute('hidden');
    }
    if (thesis != 'True') {
        document.getElementById('thesis-block').setAttribute('hidden', 'hidden');
    }
    else {
        document.getElementById('thesis-block').removeAttribute('hidden');
    }
    if (winners != 'True') {
        document.getElementById('winners-block').setAttribute('hidden', 'hidden');
    }
    else {
        document.getElementById('winners-block').removeAttribute('hidden');
    }
    currentYear = year;
}