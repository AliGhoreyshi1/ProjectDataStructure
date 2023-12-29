let html = document.querySelector('html');

function switcherEvents() {
	'use strict'

// ______________ SWITCHER-toggle ______________//

	//---skin modes-----//
	$(document).on("click", '#myonoffswitch06', function () {
		if (this.checked) {
			$('body').addClass('body-style1');
			$('body').removeClass('body-default');

			localStorage.setItem("valexbodystyle", true);
		}
	});

	$(document).on("click", '#myonoffswitch07', function () {
		if (this.checked) {
			$('body').removeClass('body-style1');
			localStorage.removeItem("valexbodystyle");
		}
	});
	//---skin modes-----//

	/*--- Left-menu Image --*/
	$('#leftmenuimage1').on('click', function () {
		$('body').removeClass('leftbgimage2');
		$('body').removeClass('leftbgimage3');
		$('body').removeClass('leftbgimage4');
		$('body').removeClass('leftbgimage5');
		$('body').addClass('leftbgimage1');

		localStorage.setItem("valexleftimage1", true);
		localStorage.removeItem("valexleftimage2");
		localStorage.removeItem("valexleftimage3");
		localStorage.removeItem("valexleftimage4");
		localStorage.removeItem("valexleftimage5");

		return false;
	});

	$('#leftmenuimage2').on('click', function () {
		$('body').removeClass('leftbgimage1');
		$('body').removeClass('leftbgimage3');
		$('body').removeClass('leftbgimage4');
		$('body').removeClass('leftbgimage5');
		$('body').addClass('leftbgimage2');

		localStorage.setItem("valexleftimage2", true);
		localStorage.removeItem("valexleftimage1");
		localStorage.removeItem("valexleftimage3");
		localStorage.removeItem("valexleftimage4");
		localStorage.removeItem("valexleftimage5");

		return false;
	});

	$('#leftmenuimage3').on('click', function () {
		$('body').removeClass('leftbgimage1');
		$('body').removeClass('leftbgimage2');
		$('body').removeClass('leftbgimage4');
		$('body').removeClass('leftbgimage5');
		$('body').addClass('leftbgimage3');

		localStorage.setItem("valexleftimage3", true);
		localStorage.removeItem("valexleftimage2");
		localStorage.removeItem("valexleftimage1");
		localStorage.removeItem("valexleftimage4");
		localStorage.removeItem("valexleftimage5");

		return false;
	});

	$('#leftmenuimage4').on('click', function () {
		$('body').removeClass('leftbgimage1');
		$('body').removeClass('leftbgimage2');
		$('body').removeClass('leftbgimage3');
		$('body').removeClass('leftbgimage5');
		$('body').addClass('leftbgimage4');

		localStorage.setItem("valexleftimage4", true);
		localStorage.removeItem("valexleftimage2");
		localStorage.removeItem("valexleftimage3");
		localStorage.removeItem("valexleftimage1");
		localStorage.removeItem("valexleftimage5");

		return false;
	});

	$('#leftmenuimage5').on('click', function () {
		$('body').removeClass('leftbgimage1');
		$('body').removeClass('leftbgimage2');
		$('body').removeClass('leftbgimage3');
		$('body').removeClass('leftbgimage4');
		$('body').addClass('leftbgimage5');

		localStorage.setItem("valexleftimage5", true);
		localStorage.removeItem("valexleftimage2");
		localStorage.removeItem("valexleftimage3");
		localStorage.removeItem("valexleftimage4");
		localStorage.removeItem("valexleftimage1");

		return false;
	});

	//***************layout-setting****************//

	$(".layout-setting").on("click", function (e) {

		if (!document.querySelector("body").classList.contains("dark-theme")) {
		  $("body").addClass("dark-theme");
		  $("body").removeClass("light-theme");
	
		  $("body")?.removeClass("color-menu");
		  $("body")?.removeClass("gradient-menu");
		  $("body")?.removeClass("light-menu");
		  $("body")?.removeClass("color-header");
		  $("body")?.removeClass("gradient-header");
		  $("body")?.removeClass("light-header");
	
		  $("#myonoffswitch5").prop("checked", true);
		  $("#myonoffswitch8").prop("checked", true);
	
		  localStorage.setItem("valexdarktheme", true);
		  localStorage.removeItem("valexlighttheme");
		  $("#myonoffswitch2").prop("checked", true);
		} else {
		  $("body").removeClass("dark-theme");
		  $("body").addClass("light-theme");
		  $("#myonoffswitch3").prop("checked", true);
		  $("#myonoffswitch6").prop("checked", true);
	
		  localStorage.setItem("valexlighttheme", true);
		  localStorage.removeItem("valexdarktheme");
		  $("#myonoffswitch1").prop("checked", true);
		}
			localStorageBackup();
			checkOptions();
	  });



	$('.default-menu').on('click', function () {
		var ww = document.body.clientWidth;
		if (ww >= 992) {
			$('body').removeClass('sidenav-toggled');
		}
	});

	/*****Horizontal-styles Start*****/
	$('#myonoffswitch31').click(function () {
		if (this.checked) {
			$('body').addClass('default-horizontal');
			$('body').removeClass('centerlogo-horizontal');
			localStorage.setItem("valexdefaultlogo", true);
			localStorage.removeItem("valexcenterlogo");
		}
	});
	$('#myonoffswitch36').click(function () {
		if (this.checked) {
			$('body').addClass('centerlogo-horizontal');
			$('body').removeClass('default-horizontal');
			localStorage.setItem("valexcenterlogo", true);
			localStorage.removeItem("valexdefaultlogo");
		}
	});
	/*****Horizontal-styles Start*****/


	/*Light Layout Start*/

	$(document).on("click", '#myonoffswitch1', function () {
		if (this.checked) {
			$('body').addClass('light-theme');
			$('#myonoffswitch3').prop('checked', true);
			$('#myonoffswitch6').prop('checked', true);
			$('body').removeClass('dark-theme');

			$('body').removeClass('color-header');
			$('body').removeClass('dark-header');
			$('body').removeClass('gradient-header');
			$('body').removeClass('dark-menu');
			$('body').removeClass('gradient-menu');
			$('body').removeClass('color-menu');

			localStorage.setItem("valexlighttheme", true);
			localStorage.removeItem("valexdarktheme");
			
			$("#myonoffswitch1").prop("checked", true);

			// checkOptions();
			const root = document.querySelector(':root');
			root.style = "";
			names()
		}
		localStorageBackup();
		checkOptions();
	});

	/*Light Layout End*/

	/*Dark Layout Start*/

	$(document).on("click", '#myonoffswitch2', function () {
		if (this.checked) {
			$('body').addClass('dark-theme');
			$('#myonoffswitch5').prop('checked', true);
			$('#myonoffswitch8').prop('checked', true);
			$('body').removeClass('light-theme');

			$('body').removeClass('light-menu');
			$('body').removeClass('color-menu');
			$('body').removeClass('gradient-menu');
			$('body').removeClass('gradient-header');
			$('body').removeClass('color-header');
			$('body').removeClass('light-header');

			localStorage.setItem("valexdarktheme", true);
			localStorage.removeItem("valexlighttheme");

			checkOptions();
			$("#myonoffswitch2").prop("checked", true);
			const root = document.querySelector(':root');
			root.style = "";
			names()
		}
		localStorageBackup();
		checkOptions();
	});

	/*Dark Layout End*/

	/*Light Menu Start*/
	$(document).on("click", '#myonoffswitch3', function () {
		if (this.checked) {
			$('body').addClass('light-menu');
			$('body').removeClass('color-menu');
			$('body').removeClass('dark-menu');
			$('body').removeClass('gradient-menu');

			localStorage.setItem("valexLightmenu", true);
			localStorage.removeItem("valexDarkmenu");
			localStorage.removeItem("valexGradientmenu");
			localStorage.removeItem("valexColormenu");
		}
	});
	/*Light Menu End*/

	/*Color Menu Start*/
	$(document).on("click", '#myonoffswitch4', function () {
		if (this.checked) {
			$('body').addClass('color-menu');
			$('body').removeClass('light-menu');
			$('body').removeClass('dark-menu');
			$('body').removeClass('gradient-menu');

			localStorage.setItem("valexColormenu", true);
			localStorage.removeItem("valexDarkmenu");
			localStorage.removeItem("valexGradientmenu");
			localStorage.removeItem("valexLightmenu");
		}
	});
	/*Color Menu End*/

	/*Dark Menu Start*/
	$(document).on("click", '#myonoffswitch5', function () {
		if (this.checked) {
			$('body').addClass('dark-menu');
			$('body').removeClass('color-menu');
			$('body').removeClass('light-menu');
			$('body').removeClass('gradient-menu');

			localStorage.setItem("valexDarkmenu", true);
			localStorage.removeItem("valexColormenu");
			localStorage.removeItem("valexGradientmenu");
			localStorage.removeItem("valexLightmenu");	
		}
	});
	/*Dark Menu End*/

	/*Gradient Menu Start*/
	$(document).on("click", '#myonoffswitch25', function () {
		if (this.checked) {
			$('body').addClass('gradient-menu');
			$('body').removeClass('color-menu');
			$('body').removeClass('light-menu');
			$('body').removeClass('dark-menu');

			localStorage.setItem("valexGradientmenu", true);
			localStorage.removeItem("valexColormenu");
			localStorage.removeItem("valexDarkmenu");
			localStorage.removeItem("valexLightmenu");
		} 
	});
	/*Gradient Menu End*/

	/*Light Header Start*/
	$(document).on("click", '#myonoffswitch6', function () {
		if (this.checked) {
			$('body').addClass('light-header');
			$('body').removeClass('color-header');
			$('body').removeClass('dark-header');
			$('body').removeClass('gradient-header');

			localStorage.setItem("valexLightheader", true);
			localStorage.removeItem("valexDarkheader");
			localStorage.removeItem("valexGradientheader");
			localStorage.removeItem("valexColorheader");
		} 
	});
	/*Light Header End*/

	/*Color Header Start*/
	$(document).on("click", '#myonoffswitch7', function () {
		if (this.checked) {
			$('body').addClass('color-header');
			$('body').removeClass('light-header');
			$('body').removeClass('dark-header');
			$('body').removeClass('gradient-header');

			localStorage.setItem("valexColorheader", true);
			localStorage.removeItem("valexDarkheader");
			localStorage.removeItem("valexGradientheader");
			localStorage.removeItem("valexLightheader");
		}
	});
	/*Color Header End*/

	/*Dark Header Start*/
	$(document).on("click", '#myonoffswitch8', function () {
		if (this.checked) {
			$('body').addClass('dark-header');
			$('body').removeClass('color-header');
			$('body').removeClass('light-header');
			$('body').removeClass('gradient-header');

			localStorage.setItem("valexDarkheader", true);
			localStorage.removeItem("valexColorheader");
			localStorage.removeItem("valexGradientheader");
			localStorage.removeItem("valexLightheader");
		}
	});
	/*Dark Header End*/

	/*Gradient Header Start*/
	$(document).on("click", '#myonoffswitch26', function () {
		if (this.checked) {
			$('body').addClass('gradient-header');
			$('body').removeClass('dark-header');
			$('body').removeClass('color-header');
			$('body').removeClass('light-header');

			localStorage.setItem("valexGradientheader", true);
			localStorage.removeItem("valexColorheader");
			localStorage.removeItem("valexDarkheader");
			localStorage.removeItem("valexLightheader");
		}
	});
	/*Gradient Header End*/

	/*Full Width Layout Start*/
	$(document).on("click", '#myonoffswitch9', function () {
		if (this.checked) {
			$('body').addClass('layout-fullwidth');
			if (document.querySelector('body').classList.contains('horizontal')) {
				checkHoriMenu();
			}
			$('body').removeClass('layout-boxed');

			localStorage.setItem("valexfullwidth", true);
			localStorage.removeItem("valexboxedwidth");
		}
	});
	/*Full Width Layout End*/

	/*Boxed Layout Start*/
	$(document).on("click", '#myonoffswitch10', function () {
		if (this.checked) {
			$('body').addClass('layout-boxed');
			if (document.querySelector('body').classList.contains('horizontal')) {
				checkHoriMenu();
			}
			$('body').removeClass('layout-fullwidth');

			localStorage.setItem("valexboxedwidth", true);
			localStorage.removeItem("valexfullwidth");
		}
	});
	/*Boxed Layout End*/

	/*Header-Position Styles Start*/
	$(document).on("click", '#myonoffswitch11', function () {
		if (this.checked) {
			$('body').addClass('fixed-layout');
			$('body').removeClass('scrollable-layout');

			localStorage.setItem("valexfixed", true);
			localStorage.removeItem("valexscrollable");
		}
	});
	$(document).on("click", '#myonoffswitch12', function () {
		if (this.checked) {
			$('body').addClass('scrollable-layout');
			$('body').removeClass('fixed-layout');

			localStorage.setItem("valexscrollable", true);
			localStorage.removeItem("valexfixed");
		}
	});
	/*Header-Position Styles End*/


	/*Default Sidemenu Start*/
	$(document).on("click", '#myonoffswitch13', function () {
		if (this.checked) {
			$('body').addClass('default-menu');
			hovermenu();
			$('body').removeClass('closed-menu');
			$('body').removeClass('icontext-menu');
			$('body').removeClass('sideicon-menu');
			$('body').removeClass('sidenav-toggled');
			$('body').removeClass('hover-submenu');
			$('body').removeClass('hover-submenu1');
			$('body').removeClass('double-menu');
			$('body').removeClass('double-menu-tabs');
			$('body').removeClass('default-horizontal');
			$('body').removeClass('centerlogo-horizontal');

			localStorage.setItem("valexdefaultmenu", true);
			localStorage.removeItem("valexclosedmenu");
			localStorage.removeItem("valexicontextmenu");
			localStorage.removeItem("valexiconoverlay");
			localStorage.removeItem("valexhoversubmenu");
			localStorage.removeItem("valexhoversubmenu1");
			localStorage.removeItem("valexdoublemenutabs");
			localStorage.removeItem("valexdoublemenu");
			localStorage.removeItem("default-horizontal");
			localStorage.removeItem("centerlogo-horizontal");
		}
	});
	/*Default Sidemenu End*/


	/*Closed Sidemenu Start*/
	$(document).on("click", '#myonoffswitch30', function () {
		if (this.checked) {
			$('body').addClass('closed-menu');
			hovermenu();
			$('body').addClass('sidenav-toggled');
			$('body').removeClass('default-menu');
			$('body').removeClass('icontext-menu');
			$('body').removeClass('sideicon-menu');
			$('body').removeClass('hover-submenu');
			$('body').removeClass('hover-submenu1');
			$('body').removeClass('double-menu');
			$('body').removeClass('double-menu-tabs');
			$('body').removeClass('default-horizontal');
			$('body').removeClass('centerlogo-horizontal');
        
			localStorage.setItem("valexclosedmenu", true);
			localStorage.removeItem("valexdefaultmenu");
			localStorage.removeItem("valexicontextmenu");
			localStorage.removeItem("valexiconoverlay");
			localStorage.removeItem("valexhoversubmenu");
			localStorage.removeItem("valexhoversubmenu1");
			localStorage.removeItem("valexdoublemenutabs");
			localStorage.removeItem("valexdoublemenu");
			localStorage.removeItem("default-horizontal");
			localStorage.removeItem("centerlogo-horizontal");
		} 
	});
	/*Closed Sidemenu End*/


	/*Hover Submenu Start*/
	$(document).on("click", '#myonoffswitch32', function () {
		if (this.checked) {
			$('body').addClass('hover-submenu');
			hovermenu();
			$('body').addClass('sidenav-toggled');
			$('body').removeClass('default-menu');
			$('body').removeClass('icontext-menu');
			$('body').removeClass('sideicon-menu');
			$('body').removeClass('closed-menu');
			$('body').removeClass('hover-submenu1');
			$('body').removeClass('double-menu');
			$('body').removeClass('double-menu-tabs');
			$('body').removeClass('default-horizontal');
			$('body').removeClass('centerlogo-horizontal');

			localStorage.setItem("valexhoversubmenu", true);
			localStorage.removeItem("valexdefaultmenu");
			localStorage.removeItem("valexclosedmenu");
			localStorage.removeItem("valexicontextmenu");
			localStorage.removeItem("valexiconoverlay");
			localStorage.removeItem("valexhoversubmenu1");
			localStorage.removeItem("valexdoublemenutabs");
			localStorage.removeItem("valexdoublemenu");
			localStorage.removeItem("default-horizontal");
			localStorage.removeItem("centerlogo-horizontal");
		}
	});
	/*Hover Submenu End*/

	/*Hover Submenu 1 Start*/
	$(document).on("click", '#myonoffswitch33', function () {
		if (this.checked) {
			$('body').addClass('hover-submenu1');
			hovermenu();
			$('body').addClass('sidenav-toggled');
			$('body').removeClass('default-menu');
			$('body').removeClass('icontext-menu');
			$('body').removeClass('sideicon-menu');
			$('body').removeClass('closed-menu');
			$('body').removeClass('hover-submenu');
			$('body').removeClass('double-menu');
			$('body').removeClass('double-menu-tabs');
			$('body').removeClass('default-horizontal');
			$('body').removeClass('centerlogo-horizontal');
        
			localStorage.setItem("valexhoversubmenu1", true);
			localStorage.removeItem("valexdefaultmenu");
			localStorage.removeItem("valexclosedmenu");
			localStorage.removeItem("valexicontextmenu");
			localStorage.removeItem("valexiconoverlay");
			localStorage.removeItem("valexhoversubmenu");
			localStorage.removeItem("valexdoublemenutabs");
			localStorage.removeItem("valexdoublemenu");
			localStorage.removeItem("default-horizontal");
			localStorage.removeItem("centerlogo-horizontal");
		}
	});
	/*Hover Submenu 1 End*/


	/*Icon Text Sidemenu Start*/
	$(document).on("click", '#myonoffswitch14', function () {
		if (this.checked) {
			$('body').addClass('icontext-menu');
			icontext();
			$('body').addClass('sidenav-toggled');
			$('body').removeClass('default-menu');
			$('body').removeClass('sideicon-menu');
			$('body').removeClass('closed-menu');
			$('body').removeClass('hover-submenu');
			$('body').removeClass('hover-submenu1');
			$('body').removeClass('double-menu');
			$('body').removeClass('double-menu-tabs');
			$('body').removeClass('default-horizontal');
			$('body').removeClass('centerlogo-horizontal');

			localStorage.setItem("valexicontextmenu", true);
			localStorage.removeItem("valexdefaultmenu");
			localStorage.removeItem("valexclosedmenu");
			localStorage.removeItem("valexiconoverlay");
			localStorage.removeItem("valexhoversubmenu");
			localStorage.removeItem("valexhoversubmenu1");
			localStorage.removeItem("valexdoublemenutabs");
			localStorage.removeItem("valexdoublemenu");
			localStorage.removeItem("default-horizontal");
			localStorage.removeItem("centerlogo-horizontal");

		}
	});
	/*Icon Text Sidemenu End*/

	/*Icon Overlay Sidemenu Start*/
	$(document).on("click", '#myonoffswitch15', function () {
		if (this.checked) {
			$('body').addClass('sideicon-menu');
			hovermenu();
			$('body').addClass('sidenav-toggled');
			$('body').removeClass('default-menu');
			$('body').removeClass('icontext-menu');
			$('body').removeClass('closed-menu');
			$('body').removeClass('hover-submenu');
			$('body').removeClass('hover-submenu1');
			$('body').removeClass('double-menu');
			$('body').removeClass('double-menu-tabs');
			$('body').removeClass('default-horizontal');
			$('body').removeClass('centerlogo-horizontal');

			localStorage.setItem("valexiconoverlay", true);
			localStorage.removeItem("valexdefaultmenu");
			localStorage.removeItem("valexclosedmenu");
			localStorage.removeItem("valexicontextmenu");
			localStorage.removeItem("valexhoversubmenu");
			localStorage.removeItem("valexhoversubmenu1");
			localStorage.removeItem("valexdoublemenutabs");
			localStorage.removeItem("valexdoublemenu");
			localStorage.removeItem("default-horizontal");
			localStorage.removeItem("centerlogo-horizontal");
		}
	});
	/*Icon Overlay Sidemenu End*/

	/***************** DOUBLE-MENU Start*********************/
	$(document).on("click", '#switchbtn-doublemenu', function () {
		if (this.checked) {
			$('body').addClass('double-menu');
			doubleLayoutFn();
			$('body').removeClass('default-menu');
			$('body').removeClass('icontext-menu');
			$('body').removeClass('sideicon-menu');
			$('body').removeClass('closed-menu');
			$('body').removeClass('hover-submenu');
			$('body').removeClass('hover-submenu1');
			$('body').removeClass('double-menu-tabs');
			$('body').removeClass('default-horizontal');
			$('body').removeClass('centerlogo-horizontal');
			localStorage.setItem("valexdoublemenu", true);
			localStorage.removeItem("valexdefaultmenu");
			localStorage.removeItem("valexclosedmenu");
			localStorage.removeItem("valexicontextmenu");
			localStorage.removeItem("valexiconoverlay");
			localStorage.removeItem("valexhoversubmenu");
			localStorage.removeItem("valexhoversubmenu1");
			localStorage.removeItem("valexdoublemenutabs");
			localStorage.removeItem("valexcenterlogo");
			localStorage.removeItem("valexdefaultlogo");
		}
	});
	/***************** DOUBLE-MENU End*********************/

	/***************** DOUBLE-MENU-TABS Start*********************/
	$(document).on("click", '#switchbtn-doublemenutabs', function () {
		if (this.checked) {
			$('body').addClass('double-menu-tabs');
			doubleLayoutFn();
			$('body').removeClass('default-menu');
			$('body').removeClass('icontext-menu');
			$('body').removeClass('sideicon-menu');
			$('body').removeClass('closed-menu');
			$('body').removeClass('hover-submenu');
			$('body').removeClass('hover-submenu1');
			$('body').removeClass('double-menu');
			$('body').removeClass('default-horizontal');
			$('body').removeClass('centerlogo-horizontal');
			localStorage.setItem("valexdoublemenutabs", true);
			localStorage.removeItem("valexdefaultmenu");
			localStorage.removeItem("valexclosedmenu");
			localStorage.removeItem("valexicontextmenu");
			localStorage.removeItem("valexsideiconmenu");
			localStorage.removeItem("valexhoversubmenu");
			localStorage.removeItem("valexhoversubmenu1");
			localStorage.removeItem("valexdoublemenu");
			localStorage.removeItem("valexcenterlogo");
			localStorage.removeItem("valexdefaultlogo");
		}
	});
	/***************** DOUBLE-MENU-TABS End*********************/

	/* Sidemenu start*/
	$(document).on("click", '#myonoffswitch34', function () {
		if (this.checked) {
			ActiveSubmenu();
			$('body').removeClass('horizontal');
			$('body').removeClass('horizontal-hover');
			$(".main-content").removeClass("horizontal-content");
			$(".main-content").addClass("app-content");
			$(".main-container").removeClass("container");
			$(".main-container").addClass("container-fluid");
			$(".main-header").removeClass("hor-header");
			$(".main-header").addClass("side-header");
			$(".app-sidebar").removeClass("horizontal-main")
			$(".main-sidemenu").removeClass("container")
			$('#slide-left').removeClass('d-none');
			$('#slide-right').removeClass('d-none');
			$('body').removeClass('default-horizontal');
			$('body').removeClass('centerlogo-horizontal');
			$('body').addClass('sidebar-mini');
			$('body').removeClass('default-horizontal');
			$('body').removeClass('centerlogo-horizontal');

			$('#myonoffswitch13').prop('checked', true);

			localStorage.setItem("valexvertical", true);
			localStorage.removeItem("valexhorizontal");
			localStorage.removeItem("valexhorizontalHover");
			localStorage.removeItem("valexdefaultlogo");
			localStorage.removeItem("valexcenterlogo");
			localStorage.removeItem("valexdoublemenu");
			localStorage.removeItem("valexdoublemenutabs");
			menuClick();
			if (document.querySelector('body').classList.contains('horizontal')&& !(document.querySelector('body').classList.contains('login-img'))) {
				checkHoriMenu();
			}
			responsive();
		} 
		else {
			$('body').removeClass('sidebar-mini');
			localStorage.setItem("valexsidebar-mini", "False");
		}
	});

	/* Sidemenu end*/


	/* horizontal click start*/

	$(document).on("click", '#myonoffswitch35', function () {
		if (this.checked) {
			if (window.innerWidth >= 992) {
				let li = document.querySelectorAll('.side-menu li')
				li.forEach((e, i) => {
					e.classList.remove('is-expanded')
				})
				var animationSpeed = 300;
				// first level
				var parent = $("[data-bs-toggle='sub-slide']").parents('ul');
				var ul = parent.find('ul[class^="slide-menu"]:visible').slideUp(animationSpeed);
				ul.removeClass('open');
				var parent1 = $("[data-bs-toggle='sub-slide2']").parents('ul');
				var ul1 = parent1.find('ul[class^="sub-slide-menu"]:visible').slideUp(animationSpeed);
				ul1.removeClass('open');
			}
			$('body').addClass('horizontal');
			$(".main-content").addClass("horizontal-content");
			$(".main-content").removeClass("app-content");
			$(".main-container").addClass("container");
			$(".main-container").removeClass("container-fluid");
			$(".main-header").addClass("hor-header");
			$(".main-header").removeClass("side-header");
			$(".app-sidebar").addClass("horizontal-main")
			$(".main-sidemenu").addClass("container")
			$('body').removeClass('sidebar-mini');
			$('body').removeClass('sidenav-toggled');
			$('body').removeClass('horizontal-hover');
			$('body').removeClass('closed-menu');
			$('body').removeClass('hover-submenu');
			$('body').removeClass('hover-submenu1');
			$('body').removeClass('icontext-menu');
			$('body').removeClass('sideicon-menu');
			$('body').removeClass('double-menu');
			$('body').removeClass('double-menu-tabs');
			$('.slide-menu').removeClass('double-menu-active');

			$('#myonoffswitch31').prop('checked', true);

			localStorage.setItem("valexhorizontal", true);
			localStorage.removeItem("valexhorizontalHover");
			localStorage.removeItem("valexvertical");
			localStorage.removeItem("valexdoublemenu");
			localStorage.removeItem("valexdoublemenutabs");
			// $('#slide-left').removeClass('d-none');
			// $('#slide-right').removeClass('d-none');
			if (document.querySelector('body').classList.contains('horizontal')&& !(document.querySelector('body').classList.contains('login-img'))) {
				document.querySelector('.horizontal .side-menu').style.flexWrap = 'noWrap';
				checkHoriMenu();
				ActiveSubmenu();
				responsive();
				menuClick();
			}
		}
	});

	/* horizontal click end*/

	/* horizontal hover start*/

	$(document).on("click", '#myonoffswitch111', function () {
		if (this.checked) {
			let li = document.querySelectorAll('.side-menu li')
			li.forEach((e, i) => {
				e.classList.remove('is-expanded')
			})
			var animationSpeed = 300;
			// first level
			var parent = $("[data-bs-toggle='sub-slide']").parents('ul');
			var ul = parent.find('ul[class^="slide-menu"]:visible').slideUp(animationSpeed);
			ul.removeClass('open');
			var parent1 = $("[data-bs-toggle='sub-slide2']").parents('ul');
			var ul1 = parent1.find('ul[class^="sub-slide-menu"]:visible').slideUp(animationSpeed);
			ul1.removeClass('open');	
			$('body').addClass('horizontal-hover');
			$('body').addClass('horizontal');
			let subNavSub = document.querySelectorAll('.sub-slide-menu');
			subNavSub.forEach((e) => {
				e.style.display = '';
			})
			let subNav = document.querySelectorAll('.slide-menu')
			subNav.forEach((e) => {
				e.style.display = '';
			})
			// $('#slide-left').addClass('d-none');
			// $('#slide-right').addClass('d-none');
			document.querySelector('.horizontal .side-menu').style.flexWrap = 'nowrap'
			$(".main-content").addClass("horizontal-content");
			$(".main-content").removeClass("app-content");
			$(".main-container").addClass("container");
			$(".main-container").removeClass("container-fluid");
			$(".main-header").addClass("hor-header");
			$(".main-header").removeClass("side-header");
			$(".app-sidebar").addClass("horizontal-main")
			$(".main-sidemenu").addClass("container")
			$('body').removeClass('sidebar-mini');
			$('body').removeClass('sidenav-toggled');
			$('body').removeClass('closed-menu');
			$('body').removeClass('hover-submenu');
			$('body').removeClass('hover-submenu1');
			$('body').removeClass('icontext-menu');
			$('body').removeClass('sideicon-menu');
			$('body').removeClass('double-menu');
			$('body').removeClass('double-menu-tabs');
			$('.slide-menu').removeClass('double-menu-active');

			$('#myonoffswitch31').prop('checked', true);

			localStorage.setItem("valexhorizontalHover", true);
			localStorage.removeItem("valexhorizontal");
			localStorage.removeItem("valexvertical");
			localStorage.removeItem("valexdoublemenu");
			localStorage.removeItem("valexdoublemenutabs");
			HorizontalHovermenu();
			if (document.querySelector('body').classList.contains('horizontal') && !(document.querySelector('body').classList.contains('login-img'))) {
				checkHoriMenu();
			}
			responsive();
		}
	});
	/* horizontal hover end*/


	/**********RTL START***********/

	$(document).on("click", '#myonoffswitch55', function () {
		if (this.checked) {
			$('body').addClass('rtl');
			$('body').removeClass('ltr');
			$("html[lang=en]").attr("dir", "rtl");
			$(".select2-container").attr("dir", "rtl");
			localStorage.setItem("valexrtl", true);
			localStorage.removeItem("valexltr");
			$("head link#style").attr("href", $(this));
			(document.getElementById("style")?.setAttribute("href", "../assets/plugins/bootstrap/css/bootstrap.rtl.min.css"));

			var carousel = $('.owl-carousel');
			$.each(carousel, function (index, element) {
				// element == this
				var carouselData = $(element).data('owl.carousel');
				carouselData.settings.rtl = true; //don't know if both are necessary
				carouselData.options.rtl = true;
				$(element).trigger('refresh.owl.carousel');
			});
			// if (document.querySelector('body').classList.contains('horizontal')) {
			// 	checkHoriMenu();
			// }
		}
	});

	/**********RTL END************/

	/**********LTR START***********/

	$(document).on("click", '#myonoffswitch54', function () {

		if (this.checked) {
			$('body').addClass('ltr');
			$('body').removeClass('rtl');
			$("html[lang=en]").attr("dir", "ltr");
			$(".select2-container").attr("dir", "ltr");
			localStorage.setItem("valexltr", true);
			localStorage.removeItem("valexrtl");
			$("head link#style").attr("href", $(this));
			(document.getElementById("style")?.setAttribute("href", "../assets/plugins/bootstrap/css/bootstrap.min.css"));
			var carousel = $('.owl-carousel');
			$.each(carousel, function (index, element) {
				// element == this
				var carouselData = $(element).data('owl.carousel');
				carouselData.settings.rtl = false; //don't know if both are necessary
				carouselData.options.rtl = false;
				$(element).trigger('refresh.owl.carousel');
			});
		}
	});

	/**********LTR END************/

	
	/***************** Add Switcher Classes *********************/
	//LTR & RTL
	if (!localStorage.getItem('valexrtl') && !localStorage.getItem('valexltr')) {

		/***************** RTL *********************/
		// $('body').addClass('rtl');
		/***************** RTL *********************/
		/***************** LTR *********************/
		// $('body').addClass('ltr');
		/***************** LTR *********************/

	}
	//Light-theme & dark-theme
	if (!localStorage.getItem('valexlighttheme') && !localStorage.getItem('valexdarktheme')) {
		/***************** Light THEME *********************/
		// $('body').addClass('light-theme');
		/***************** Light THEME *********************/

		/***************** DARK THEME *********************/
		// $('body').addClass('dark-theme');
		/***************** Dark THEME *********************/
	}

	//Vertical-menu & Horizontal-menu
	if (!localStorage.getItem('valexvertical') && !localStorage.getItem('valexhorizontal') && !localStorage.getItem('valexhorizontalHover')) {
		/***************** Horizontal *********************/
		// $('body').addClass('horizontal');
		/***************** Horizontal *********************/

		/***************** Horizontal-Hover *********************/
		// $('body').addClass('horizontal-hover');
		/***************** Horizontal-Hover *********************/
	}

	//Vertical Layout Style
	if (!localStorage.getItem('valexdefaultmenu') && !localStorage.getItem('valexclosedmenu') && !localStorage.getItem('valexicontextmenu')&& !localStorage.getItem('valexiconoverlay')&& !localStorage.getItem('valexhoversubmenu')&& !localStorage.getItem('valexhoversubmenu1')&& !localStorage.getItem('valexdoublemenu')&& !localStorage.getItem('valexdoublemenutabs')) {
		/**Default-Menu**/
		// $('body').addClass('default-menu');
		/**Default-Menu**/

		/**closed-Menu**/
		// $('body').addClass('closed-menu');
		/**closed-Menu**/

		/**Icon-Text-Menu**/
		// $('body').addClass('icontext-menu');
		/**Icon-Text-Menu**/

		/**Icon-Overlay-Menu**/
		// $('body').addClass('sideicon-menu');
		/**Icon-Overlay-Menu**/

		/**Hover-Sub-Menu**/
		// $('body').addClass('hover-submenu');
		/**Hover-Sub-Menu**/

		/**Hover-Sub-Menu1**/
		// $('body').addClass('hover-submenu1');
		/**Hover-Sub-Menu1**/

		/**Double-Menu**/
		// $('body').addClass('double-menu');
		/**Double-Menu**/

		/**Double-Menu-Tabs**/
		// $('body').addClass('double-menu-tabs');
		/**Double-Menu-Tabs**/
	}

	//Horizontal Logo Style
	if (!localStorage.getItem('valexdefaultlogo') && !localStorage.getItem('valexcenterlogo')) {
		/**Default-Logo**/
		// $('body').addClass('default-horizontal');
		/**Default-Logo**/

		/**Center-Logo**/
		// $('body').addClass('centerlogo-horizontal');
		/**Center-Logo**/

	}

	//Boxed Layout Style
	if (!localStorage.getItem('valexfullwidth') && !localStorage.getItem('valexboxedwidth')) {
	// $('body').addClass('layout-boxed');
	}

	//Scrollable-Layout Style
	if (!localStorage.getItem('valexfixed') && !localStorage.getItem('valexscrollable')) {
	// $('body').addClass('scrollable-layout');
	}

	//Menu Styles
	if (!localStorage.getItem('valexLightmenu') && !localStorage.getItem('valexColormenu') && !localStorage.getItem('valexDarkmenu') && !localStorage.getItem('valexGradientmenu')) {
		/**Light-menu**/
		// $('body').addClass('light-menu');
		/**Light-menu**/

		/**Color-menu**/
		// $('body').addClass('color-menu');
		/**Color-menu**/

		/**Dark-menu**/
		// $('body').addClass('dark-menu');
		/**Dark-menu**/

		/**Gradient-menu**/
		// $('body').addClass('gradient-menu');
		/**Gradient-menu**/
	}
	//Header Styles
	if (!localStorage.getItem('valexLightheader') && !localStorage.getItem('valexDarkheader') && !localStorage.getItem('valexColorheader') && !localStorage.getItem('valexGradientheader')) {
		/**Light-Header**/
		// $('body').addClass('light-header');
		/**Light-Header**/

		/**Color-Header**/
		// $('body').addClass('color-header');
		/**Color-Header**/

		/**Dark-Header**/
		// $('body').addClass('dark-header');
		/**Dark-Header**/
		/**Color-Header**/

		/**Gradient-Header**/
		// $('body').addClass('gradient-header');
		/**Gradient-Header**/

	}

	 // BODY STYLE

	 if (!localStorage.getItem('valexdefaultstyle') && !localStorage.getItem('valexbodystyle')) {

		// $('body').addClass('body-style1');
	  
	  }

	   // LEFTMENU IMAGE STYLES

	   if (!localStorage.getItem('valexleftimage1') && !localStorage.getItem('valexleftimage2') && !localStorage.getItem('valexleftimage3') && !localStorage.getItem('valexleftimage4') && !localStorage.getItem('valexleftimage5')) {

		/**leftbgimage1**/
  
		// $('body').addClass('leftbgimage1');
  
		/**leftbgimage1**/
  
		/**leftbgimage2**/
  
		// $('body').addClass('leftbgimage2');
  
		/**leftbgimage2**/
  
		/**leftbgimage3**/
  
		// $('body').addClass('leftbgimage3');
  
		/**leftbgimage3**/
  
		/**leftbgimage4**/
  
		// $('body').addClass('leftbgimage4');
  
		/**leftbgimage4**/
  
		/**leftbgimage5**/
  
		// $('body').addClass('leftbgimage5');
  
		/**leftbgimage5**/
  
	  }
	/***************** Add Switcher Classes *********************/

}
switcherEvents();


(function () {
	"use strict";

	

/////////////////RTL Start//////////////////////

	let bodyRtl = $('body').hasClass('rtl');
	if (bodyRtl) {
	$('body').addClass('rtl');
	$('body').removeClass('ltr');
	$("html[lang=en]").attr("dir", "rtl");
	$(".select2-container").attr("dir", "rtl");
	$("head link#style").attr("href", $(this));
	(document.getElementById("style")?.setAttribute("href", "../assets/plugins/bootstrap/css/bootstrap.rtl.min.css"));

	var carousel = $('.owl-carousel');
	$.each(carousel, function (index, element) {
		// element == this
		var carouselData = $(element).data('owl.carousel');
		carouselData.settings.rtl = true; //don't know if both are necessary
		carouselData.options.rtl = true;
		$(element).trigger('refresh.owl.carousel');
	});
	if (document.querySelector('body').classList.contains('horizontal')&& !(document.querySelector('body').classList.contains('login-img'))) {
		checkHoriMenu();
	}
	}

/////////////////RTL End//////////////////////

/////////////////Horizontal Start//////////////////////horizontalMenucontainer
if ($("body").hasClass("horizontal")) {
// ActiveSubmenu();
if (window.innerWidth >= 992) {
	let li = document.querySelectorAll('.side-menu li')
	li.forEach((e, i) => {
		e.classList.remove('is-expanded')
	})
	var animationSpeed = 300;
	// first level
	var parent = $("[data-bs-toggle='sub-slide']").parents('ul');
	var ul = parent.find('ul[class^="slide-menu"]:visible').slideUp(animationSpeed);
	ul.removeClass('open');
	var parent1 = $("[data-bs-toggle='sub-slide2']").parents('ul');
	var ul1 = parent1.find('ul[class^="sub-slide-menu"]:visible').slideUp(animationSpeed);
	ul1.removeClass('open');
}
$('body').addClass('horizontal');
$(".main-content").addClass("horizontal-content");
$(".main-content").removeClass("app-content");
$(".main-container").addClass("container");
$(".main-container").removeClass("container-fluid");
$(".main-header").addClass("hor-header");
$(".main-header").removeClass("side-header");
$(".app-sidebar").addClass("horizontal-main")
$(".main-sidemenu").addClass("container")
$('body').removeClass('sidebar-mini');
$('body').removeClass('sidenav-toggled');
$('body').removeClass('horizontal-hover');
$('body').removeClass('closed-menu');
$('body').removeClass('hover-submenu');
$('body').removeClass('hover-submenu1');
$('body').removeClass('icontext-menu');
$('body').removeClass('sideicon-menu');
$('body').removeClass('double-menu');
$('body').removeClass('double-menu-tabs');
$('.slide-menu').removeClass('double-menu-active');
// $('#slide-left').removeClass('d-none');
// $('#slide-right').removeClass('d-none');
if (document.querySelector('body').classList.contains('horizontal')&& !(document.querySelector('body').classList.contains('login-img'))) {
	document.querySelector('.horizontal .side-menu').style.flexWrap = 'noWrap';
	checkHoriMenu();
	ActiveSubmenu();
	menuClick();
	responsive();
}
}
/////////////////Horizontal End//////////////////////

/////////////////Horizontal-Hover Start//////////////////////
if ($("body").hasClass("horizontal-hover")) {
let li = document.querySelectorAll('.side-menu li')
li.forEach((e, i) => {
	e.classList.remove('is-expanded')
})
var animationSpeed = 300;
// first level
var parent = $("[data-bs-toggle='sub-slide']").parents('ul');
var ul = parent.find('ul[class^="slide-menu"]:visible').slideUp(animationSpeed);
ul.removeClass('open');
var parent1 = $("[data-bs-toggle='sub-slide2']").parents('ul');
var ul1 = parent1.find('ul[class^="sub-slide-menu"]:visible').slideUp(animationSpeed);
ul1.removeClass('open');
$('body').addClass('horizontal-hover');
$('body').addClass('horizontal');
let subNavSub = document.querySelectorAll('.sub-slide-menu');
subNavSub.forEach((e) => {
	e.style.display = '';
})
let subNav = document.querySelectorAll('.slide-menu')
subNav.forEach((e) => {
	e.style.display = '';
})
// $('#slide-left').addClass('d-none');
// $('#slide-right').addClass('d-none');

$(".main-content").addClass("horizontal-content");
$(".main-content").removeClass("app-content");
$(".main-container").addClass("container");
$(".main-container").removeClass("container-fluid");
$(".main-header").addClass("hor-header");
$(".main-header").removeClass("side-header");
$(".app-sidebar").addClass("horizontal-main")
$(".main-sidemenu").addClass("container")
$('body').removeClass('sidebar-mini');
$('body').removeClass('sidenav-toggled');
$('body').removeClass('closed-menu');
$('body').removeClass('hover-submenu');
$('body').removeClass('hover-submenu1');
$('body').removeClass('icontext-menu');
$('body').removeClass('sideicon-menu');
$('body').removeClass('double-menu');
$('body').removeClass('double-menu-tabs');
$('.slide-menu').removeClass('double-menu-active');

if (document.querySelector('body').classList.contains('horizontal')&& !(document.querySelector('body').classList.contains('login-img'))) {
	document.querySelector('.horizontal .side-menu').style.flexWrap = 'nowrap'
	checkHoriMenu();
	HorizontalHovermenu();
	responsive();
}

}
/////////////////Horizontal-Hover End//////////////////////

	/***************** CLOSEDMENU has Class *********************/
	let bodyclosed = $('body').hasClass('closed-menu');
	if (bodyclosed) {
		$('body').addClass('closed-menu');
		if (!(document.querySelector('body').classList.contains('login-img'))) {
			hovermenu();
		}
		$('body').addClass('sidenav-toggled');
	}
	/***************** CLOSEDMENU has Class *********************/

	/***************** ICONTEXT MENU has Class *********************/
	let bodyicontext = $('body').hasClass('icontext-menu');
	if (bodyicontext) {
		$('body').addClass('icontext-menu');
		if (!(document.querySelector('body').classList.contains('login-img'))) {
			icontext();
		}
		$('body').addClass('sidenav-toggled');
	}
	/***************** ICONTEXT MENU has Class *********************/

	/***************** ICONOVERLAY MENU has Class *********************/
	let bodyiconoverlay = $('body').hasClass('sideicon-menu');
	if (bodyiconoverlay) {
		$('body').addClass('sideicon-menu');
		if (!(document.querySelector('body').classList.contains('login-img'))) {
			hovermenu();
		}
		$('body').addClass('sidenav-toggled');
	}
	/***************** ICONOVERLAY MENU has Class *********************/

	/***************** HOVER-SUBMENU has Class *********************/
	let bodyhover = $('body').hasClass('hover-submenu');
	if (bodyhover) {
		$('body').addClass('hover-submenu');
		if (!(document.querySelector('body').classList.contains('login-img'))) {
			hovermenu();
		}
		$('body').addClass('sidenav-toggled');
	}
	/***************** HOVER-SUBMENU has Class *********************/

	/***************** HOVER-SUBMENU has Class *********************/
	let bodyhover1 = $('body').hasClass('hover-submenu1');
	if (bodyhover1) {
		$('body').addClass('hover-submenu1');
		if (!(document.querySelector('body').classList.contains('login-img'))) {
			hovermenu();
		}
		$('body').addClass('sidenav-toggled');
	}
	/***************** HOVER-SUBMENU has Class *********************/

	/***************** Double-Menu has Class *********************/
	let bodydoublemenu = $('body').hasClass('double-menu');
	if (bodydoublemenu) {
		$('body').addClass('double-menu');
		if (!(document.querySelector('body').classList.contains('login-img'))) {
			doublemenu();
		}
	}
	/***************** Double-Menu has Class *********************/

	/***************** Double-Menu-Tabs has Class *********************/
	let bodydoublemenutabs = $('body').hasClass('double-menu-tabs');
	if (bodydoublemenutabs) {
		$('body').addClass('double-menu-tabs');
		if (!(document.querySelector('body').classList.contains('login-img'))) {
			doublemenu();
		}
	}
	/***************** Double-Menu-Tabs has Class *********************/

	checkOptions();
})()

function checkOptions() {
	'use strict'

	// dark-theme
	if (document.querySelector('body').classList.contains('dark-theme')) {
		$('#myonoffswitch2').prop('checked', true);
	}

	// horizontal
	if (document.querySelector('body').classList.contains('horizontal')) {
		$('#myonoffswitch35').prop('checked', true);
	}

	// horizontal-hover
	if (document.querySelector('body').classList.contains('horizontal-hover')) {
		$('#myonoffswitch111').prop('checked', true);
	}

	//RTL 
	if (document.querySelector('body').classList.contains('rtl')) {
		$('#myonoffswitch55').prop('checked', true);
	}

	// light header 
	if (document.querySelector('body').classList.contains('light-header')) {
		$('#myonoffswitch6').prop('checked', true);
	}
	// color header 
	if (document.querySelector('body').classList.contains('color-header')) {
		$('#myonoffswitch7').prop('checked', true);
	}
	// gradient header 
	if (document.querySelector('body').classList.contains('gradient-header')) {
		$('#myonoffswitch26').prop('checked', true);
	}
	// dark header 
	if (document.querySelector('body').classList.contains('dark-header')) {
		$('#myonoffswitch8').prop('checked', true);
	}

	// light menu
	if (document.querySelector('body').classList.contains('light-menu')) {
		$('#myonoffswitch3').prop('checked', true);
	}
	// color menu
	if (document.querySelector('body').classList.contains('color-menu')) {
		$('#myonoffswitch4').prop('checked', true);
	}
	// gradient menu
	if (document.querySelector('body').classList.contains('gradient-menu')) {
		$('#myonoffswitch25').prop('checked', true);
	}
	// dark menu
	if (document.querySelector('body').classList.contains('dark-menu')) {
		$('#myonoffswitch5').prop('checked', true);
	}
	// default logo
	if (document.querySelector('body').classList.contains('default-horizontal')) {
		$('#myonoffswitch31').prop('checked', true);
	}
	// center logo
	if (document.querySelector('body').classList.contains('centerlogo-horizontal')) {
		$('#myonoffswitch36').prop('checked', true);
	}
	// body style1
	if (document.querySelector('body').classList.contains('body-style1')) {
		$('#myonoffswitch06').prop('checked', true);
	}
	// layout-boxed
	if (document.querySelector('body').classList.contains('layout-boxed')) {
		$('#myonoffswitch10').prop('checked', true);
	}
	// scrollable-layout
	if (document.querySelector('body').classList.contains('scrollable-layout')) {
		$('#myonoffswitch12').prop('checked', true);
	}
	// icontext-menu
	if (document.querySelector('body').classList.contains('icontext-menu')) {
		$('#myonoffswitch14').prop('checked', true);
	}
	// closed-menu
	if (document.querySelector('body').classList.contains('closed-menu')) {
		$('#myonoffswitch30').prop('checked', true);
	}
	// sideicon-menu
	if (document.querySelector('body').classList.contains('sideicon-menu')) {
		$('#myonoffswitch15').prop('checked', true);
	}
	// hover-submenu
	if (document.querySelector('body').classList.contains('hover-submenu')) {
		$('#myonoffswitch32').prop('checked', true);
	}
	// hover-submenu1
	if (document.querySelector('body').classList.contains('hover-submenu1')) {
		$('#myonoffswitch33').prop('checked', true);
	}
	// double-menu
	if (document.querySelector('body').classList.contains('double-menu')) {
		$('#switchbtn-doublemenu').prop('checked', true);
	}
	// double-menu-tabs
	if (document.querySelector('body').classList.contains('double-menu-tabs')) {
		$('#switchbtn-doublemenutabs').prop('checked', true);
	}
}
checkOptions()
	
function resetData() {
	'use strict'
	$('#myonoffswitch1').prop('checked', true);
	$('#myonoffswitch6').prop('checked', true);
	$('#myonoffswitch9').prop('checked', true);
	$('#myonoffswitch11').prop('checked', true);
	$('#myonoffswitch34').prop('checked', true);
	$('#myonoffswitch54').prop('checked', true);
	$('#myonoffswitch13').prop('checked', true);
	$('#myonoffswitch07').prop('checked', true);
	$('#myonoffswitch3').prop('checked', true);
	$('body')?.removeClass('dark-theme');
	$('body')?.removeClass('dark-menu');
	$('body')?.removeClass('light-menu');
	$('body')?.removeClass('color-menu');
	$('body')?.removeClass('gradient-menu');
	$('body')?.removeClass('dark-header');
	$('body')?.removeClass('gradient-header');
	$('body')?.removeClass('light-header');
	$('body')?.removeClass('color-header');
	$('body')?.removeClass('body-style1');
	$('body')?.removeClass('layout-boxed');
	$('body')?.removeClass('icontext-menu');
	$('body')?.removeClass('sideicon-menu');
	$('body')?.removeClass('closed-menu');
	$('body')?.removeClass('hover-submenu');
	$('body')?.removeClass('hover-submenu1');
	$('body')?.removeClass('double-menu-tabs');
	$('body')?.removeClass('double-menu');
	$(".tab-content-show").addClass("active");
	$(".tab-content-double").removeClass("active")
	$('.slide-menu')?.removeClass('double-menu-active');
	$('body')?.removeClass('scrollable-layout');
	$('body')?.removeClass('sidenav-toggled');
	$('body')?.removeClass('leftbgimage1');
	$('body')?.removeClass('leftbgimage2');
	$('body')?.removeClass('leftbgimage3');
	$('body')?.removeClass('leftbgimage4');
	$('body')?.removeClass('leftbgimage5');
	$('body')?.removeClass('centerlogo-horizontal');


	$('body').removeClass('horizontal');
	$('body').removeClass('horizontal-hover');
	$(".main-content").removeClass("horizontal-content");
	$(".main-content").addClass("app-content");
	$(".main-container").removeClass("container");
	$(".main-container").addClass("container-fluid");
	$(".main-header").removeClass("hor-header");
	$(".main-header").addClass("side-header");
	$(".app-sidebar").removeClass("horizontal-main")
	$(".main-sidemenu").removeClass("container")
	$('#slide-left').removeClass('d-none');
	$('#slide-right').removeClass('d-none');
	$('body').addClass('sidebar-mini');
	if (document.querySelector('body').classList.contains('horizontal')) {
		checkHoriMenu();
		menuClick();
		responsive();
	}

	$('body').addClass('ltr');
	$('body').removeClass('rtl');
	$("html[lang=en]").attr("dir", "ltr");
	$(".select2-container").attr("dir", "ltr");
	$("head link#style").attr("href", $(this));
	(document.getElementById("style")?.setAttribute("href", "../assets/plugins/bootstrap/css/bootstrap.min.css"));
	var carousel = $('.owl-carousel');
	$.each(carousel, function (index, element) {
		// element == this
		var carouselData = $(element).data('owl.carousel');
		carouselData.settings.rtl = false; //don't know if both are necessary
		carouselData.options.rtl = false;
		$(element).trigger('refresh.owl.carousel');
		if (document.querySelector('body').classList.contains('horizontal')) {
			checkHoriMenu();
		}
	});
}
