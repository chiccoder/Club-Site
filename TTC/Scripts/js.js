//var viewportwidth;
//var viewportheight;

//$(document).ready(function(){
//	resizePage();
//	$('#container').center();
//	$(window).resize(function(){
//		resizePage();
//		$('#container').center();
//		});
//	var $contentDivs = $('#contentContainer div');
//	$('#contentContainer div').each(function(){
//		$(this).hover(function(){
//			$(this).css({'box-shadow': 'inset 0 0 1px #000000'});
//		});
//		$(this).mouseleave(function(){
//			$(this).css({'box-shadow': 'inset 0 0 5px #000000'});
//		});
//		$(this).click(function(){
//			$(this).animate({height: $(window).height()/1.4-$('#header').height()});
//			$(this).addClass('on');
//			$('#contentContainer div').each(function(){
//				if ($(this).attr('class') != 'on') {
//					$(this).animate({height: ($(window).height()/4.7-$('#header').height())+"px"});
//				}
//			});
//			$(this).removeClass('on');
//		});
//	});
//	$('#header').click(function(){
//		$('#contentContainer div').each(function(){
//				if ($(this).attr('class') != 'on') {
//					$(this).animate({height: ($(window).height()/3-$('#header').height())+"px"});
//				}
//			});
//	});
//});

//function resizePage() {
//	$viewportheight = $(window).height()
//	$viewportwidth = $(window).width()
//	$contentHeight = $(window).height()-$('#header').height()-10
//	$contentWidth = $(window).width()
//	$('#container').animate({height: $contentHeight+"px", width: $viewportwidth+"px"});
//	$('#home').animate({height: $contentHeight/4+"px", width: $viewportwidth+'px'});
//	$('#about').animate({height: $contentHeight/4+"px", width: $viewportwidth+'px'});
//	$('#signUp').animate({height: $contentHeight/4+"px", width: $viewportwidth+'px'});
//	$('#calendar').animate({height: $contentHeight/4+"px", width: $viewportwidth+'px'});
//}
//jQuery.fn.center = function () {
//    this.css({'margin-left': 'auto'});
//    this.css({'margin-right': 'auto'});
   
//    return this;
//}

