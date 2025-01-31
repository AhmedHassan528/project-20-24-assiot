﻿let burger = document.getElementById('burger'),
	nav = document.getElementById('main-nav');

burger.addEventListener('click', function (e) {
	this.classList.toggle('is-open');
	nav.classList.toggle('is-open');
});


/* Onload demo - dirty timeout */
let clickEvent = new Event('click');

window.addEventListener('load', function (e) {
	slowmo.dispatchEvent(clickEvent);
	burger.dispatchEvent(clickEvent);

	setTimeout(function () {
		burger.dispatchEvent(clickEvent);

		setTimeout(function () {
			slowmo.dispatchEvent(clickEvent);
		}, 3500);
	}, 5500);
});