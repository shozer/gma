jQuery.fn.modal = function(options){
	
	// VERIFICANDO O HREF
	if(!options){
		if(this.attr('href')) var options = { url: this.attr('href') };
	} else {
		if(!options.url)if(this.attr('href')) options.url = this.attr('href');
	}
	
	var settings = { 
		url: '#',
		backgroundColor: '#000',
		backgroundOpacity: 0.5,
		position: 'center',
		referencePosition: this,
		top:0,
		left:0,
		closeEsc:true,
		closeClickOut: false,
		autoOpen: false
	};
	options = jQuery.extend(settings, options);
	
	
	function openModal(){
		/*CREATE ELEMENTS*/
		/*jQuery('body').append(jQuery('<img />').attr({src: "img/load.gif", width: 128, height: 15, alt: "", className: 'load'})).append(jQuery('<div></div>').addClass('bg_modal')).append(jQuery('<div></div>').addClass('view_modal'));*/
		jQuery('body').append(jQuery('<div></div>').addClass('bg_modal')).append(jQuery('<div></div>').addClass('view_modal'));
		
		// verificando se o body é menor do que o screen
		var altura = jQuery('html')[0].scrollHeight < jQuery(window).height() ? jQuery(window).height() : jQuery('html')[0].scrollHeight;
		jQuery('.bg_modal').width(jQuery('html')[0].scrollWidth).height(altura);
		
		/*OPACITY*/
		if(options.backgroundOpacity != 0){
			jQuery('.bg_modal').css('background-color',options.backgroundColor);
			jQuery('.view_modal').css('opacity', 0);
			jQuery('.bg_modal').css('opacity', 0);
		}
		
		// escondendo selects
		jQuery('select').css('visibility', 'hidden');

		// posicionamento
		if(options.position=='relative'){
			var offset  = options.referencePosition.offset();
			leftModal = offset.left;		
			topModal =  offset.top;		
		}
		
		/*SHOW BACKGROUND*/
		jQuery('.bg_modal').fadeTo('fast', options.backgroundOpacity, function() {
			jQuery('.view_modal').load(options.url, function() {
			
				/*REMOVE LOAD*/
				jQuery('.load').remove();
				
				GB_getPageScrollTop = function() {
					var yScrolltop;
					if (self.pageYOffset) {
						yScrolltop = self.pageYOffset;
					} else if (document.documentElement && document.documentElement.scrollTop || document.documentElement.scrollLeft) {
						yScrolltop = document.documentElement.scrollTop;
					} else if (document.body) {
						yScrolltop = document.body.scrollTop;
					}
					return yScrolltop;
				}
				
				/*CENTRALIZE MODAL*/
				if(options.position!='center'){
					var alturaModal = parseInt(options.top) + parseInt(topModal) + parseInt(jQuery('.view_modal').height());
					if(altura<alturaModal){
						options.top = 0;
						topModal = altura - parseInt(jQuery('.view_modal').height());
					}					
					jQuery('.view_modal').css({
							marginTop: topModal, 
							marginLeft: leftModal,
							left: options.left, 
							top: options.top
						}
					);
					
				} else {
					jQuery('.view_modal').css({marginTop: parseInt(GB_getPageScrollTop() - (jQuery('.view_modal').height()/2)), marginLeft: -parseInt(jQuery('.view_modal').width()/2)});
				}

				/*MODAL HIDE*/
				if(options.backgroundOpacity != 0) jQuery('.view_modal').fadeTo('fast', 1);

				/*CLOSE MODAL*/
				jQuery("a[rel='modalclose']").click(function() {
					closeModal();
					return false;
				})
			});
		});		
		
		
		if(options.closeClickOut==true){
			jQuery('.bg_modal').click(function(){
				closeModal();
			});
		}
		

		if(options.closeEsc==true){
			jQuery(window).keydown(function(event){
				if(event.keyCode==27)closeModal();
			});
		}
		return false;
	}
	


	if(options.autoOpen == false){
		this.click(openModal);	
	} else {
		openModal();
	}
	
	
	
	
	/*CLOSE MODAL*/
	function closeModal(){
		/*HIDE MODAL*/
		jQuery('.view_modal').fadeTo('fast', 0, function(){jQuery(this).remove();});
		
		/*HIDE BACKGROUND*/
		jQuery('.bg_modal').fadeTo('fast', 0, function() {
			jQuery(this).remove();
			jQuery('select').css('visibility', 'visible');
		});
		
		jQuery(window).unbind();
		jQuery('.bg_modal').unbind();
	}	

	
	this.css('visibility','visible');
};

jQuery(document).ready(function(){
	jQuery('a[rel="modal"]').each(function(){
		jQuery(this).modal();	
	});
});

