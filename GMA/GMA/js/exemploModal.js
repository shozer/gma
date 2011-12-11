jQuery(document).ready(function(){

	/* ACORDDION */
	jQuery('h2.accordion').click(function(){
		jQuery(this).parent().find('div.accordion').slideToggle("slow");
	});
	
	
	/* !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Básico  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! */
	jQuery('a#exemplo_simples').modal();	
	jQuery('button#exemplo_button').modal({
		url:'http://www.tidbits.com.br/download/exemplos/modal/exemplo_modal.html'
	});	

	
	
	/* !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! backgroundColor  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! */
	jQuery('a#exemplo_vermelho').modal({
		backgroundColor:'#ff0000'
	});
	jQuery('a#exemplo_amarelo').modal({
		backgroundColor:'#ffff00'
	});
	jQuery('a#exemplo_azul').modal({
		backgroundColor:'#0000FF'
	});	
	
	
	
	/* !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! backgroundOpacity  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! */
	jQuery('a#exemplo_opacity').modal({
		backgroundOpacity:0
	});		
	jQuery('a#exemplo_fundo_claro').modal({
		backgroundOpacity:0.2
	});	
	jQuery('a#exemplo_fundo_escuro').modal({
		backgroundOpacity:0.7
	});			
	jQuery('a#exemplo_fundo_preto').modal({
		backgroundOpacity:1
	});	
		
		
		
	/* !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Posicionamento  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! */	
	jQuery('a#exemplo_posicao_relativa').modal({
		position:'relative'
	});			
	jQuery('a#exemplo_com_referencia').modal({
		position: 'relative',
		referencePosition: jQuery('div#exemploReferencia')
	});		
	jQuery('a#exemplo_left').modal({
		position: 'relative',
		referencePosition: jQuery('div#top_left'),
		left:30
	});		
	jQuery('a#exemplo_top').modal({
		position: 'relative',
		referencePosition: jQuery('div#top_left'),
		top:40
	});	
	jQuery('a#exemplo_top_left').modal({
		position: 'relative',
		referencePosition: jQuery('div#top_left'),
		top:20,
		left: -50
	});			
	jQuery('a#exemplo_left2').modal({
		position: 'relative',
		left: 250
	});	
	
	/* !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Exemplo sem ESC  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! */		
	jQuery('a#exemplo_esc').modal({
		closeEsc: false
	});		
	
	/* !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Exemplo sem ESC  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! */		
	jQuery('a#exemplo_clickOut').modal({
		closeClickOut: true
	});			
});
