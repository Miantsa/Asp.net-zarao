function GetMusique() {
    $.ajax({
        type: 'POST',
        url: "default.aspx/GetMusique",
        contentType: "application/json;charset=utf-8",
        dataType: 'json',
        success: function (data) { 
        var h={};
            var dt=JSON.parse(data.d);
             $("#NumMusique").text(dt.length);
          // alert(dt.length);
            var num=0;
           dt.forEach(musique=>{
               // console.log(musique.Titre);
                $("#liste-musique").append(" <ul ><li ><input type='checkbox' class='filled-in red choix-musique'   id='musique"+num+"' name='"+musique.Lien+"'/><label  for='musique"+num+"'></label></li><li><span>"+musique.Titre+"</span></li><li ><div ><i class='material-icons PlayMusique' name='"+musique.Lien+"'>play_arrow</i><a href='Zarao_dossier/Musiques/"+musique.Lien+"' download><i class='material-icons'>file_download</i></a><i class='material-icons DeleteMusique' name='"+musique.Lien+"' >delete</i></div></li><li><span>"+musique.Artiste+"</span></li><li><span>"+musique.Duree+"</span></li><li><span>"+musique.Format+"</span></li><li><span>"+musique.Taille+"</span></li> </ul>");
                //i++;
                h[musique.Lien]=0;
                num++;
                console.log("lasa");
           });  
           var id=0;
           if(dt.length>0){
                $("#audio audio").attr("src","Zarao_Dossier/Musiques/"+dt[0].Lien);
                $("#title-track").text(dt[0].Titre);
                $("#artiste-track").text(dt[0].Artiste);
                //precedent
                 $("#prev-track").on("click",function(){
                    id--;
                    if(id>=0){
                        $("#audio audio").attr("src","Zarao_Dossier/Musiques/"+dt[id].Lien);
                        $("#title-track").text(dt[id].Titre);
                        $("#artiste-track").text(dt[id].Artiste);
                        $("#audio audio").trigger('play');
                    }
                });
                //suivant
                $("#next-track").on("click",function(){
                    id++;
                    if(id<=dt.length){
                        $("#audio audio").attr("src","Zarao_Dossier/Musiques/"+dt[id].Lien);
                        $("#title-track").text(dt[id].Titre);
                        $("#artiste-track").text(dt[id].Artiste);
                        $("#audio audio").trigger('play');
                    }
                });
                 $("#audio audio").bind('ended',function(){
                    id++;
                    if(i<=dt.length){
                       $("#audio audio").attr("src","Zarao_Dossier/Musiques/"+dt[id].Lien);
                       $("#title-track").text(dt[id].Titre);
                        $("#artiste-track").text(dt[id].Artiste);
                       $("#audio audio").trigger('play');
                    }
                 });
            }
                $(".PlayMusique").on("click",function(){
                    for(var i=0;i<dt.length;i++){
                        if(dt[i].Lien==$(this).attr("name")){
                           // alert("mitovy:"+i); 
                           id=i;
                            $("#audio audio").attr("src","Zarao_Dossier/Musiques/"+dt[id].Lien);
                            $("#title-track").text(dt[id].Titre);
                            $("#artiste-track").text(dt[id].Artiste);
                            $("#audio audio").trigger('play');
                            break; 
                        }
                    }
                });  
                for(var x=0;x<dt.length;x++){
                 $("#musique"+x).prop("checked",false);
                }
               /* dt.forEach(musique=>{
                    $("#"+musique.Lien).prop("checked",false);
                    console.log(musique.Lien);
                });*/
                $(".choix-musique").on("click",function(){
                    if($(this).prop("checked")){
                        h[$(this).attr("name")]=1;
                    }else{
                        h[$(this).attr("name")]=0;
                    }
                    var i=0;
                    dt.forEach(item=>{
                        if(h[item.Lien]==1)
                            i++;
                    });
                    if(i>0){
                        $("#DownloadMusique").removeClass("disabled");
                        $("#DeleteMusique").removeClass("disabled");
                    }
                    else{
                        $("#DownloadMusique").addClass("disabled");
                        $("#DeleteMusique").addClass("disabled");
                    }
                    //alert($(this).attr("id"));  
                });
                $(".DeleteMusique").on("click",function(){
                   // alert($(this).attr("name"));
                    var nom=$(this).attr("name");
                        $( "#dialogMusique1" ).dialog({
	                    autoOpen: false,
	                    width: 300,
	                    buttons: [
		                    {
			                    text: "Ok",
			                    click: function() {
				                    $( this ).dialog( "close" );
                                    //alert(liste[1]);
                                        $.ajax({
                                        type: "POST",
                                        url: "default.aspx/DeleteMusiqueSolo",
                                        data:"{'musique':'"+nom+"'}",
                                        contentType: "application/json;charset=utf-8",
                                        dataType: 'json',
                                        success: function (data) {
                                            //alert(data.d);
                                            if(data.d)
                                                RefreshMusique();
                                        },
                                        });
			                    }
		                    },
		                    {
			                    text: "Cancel",
			                    click: function() {
				                    $( this ).dialog( "close" );
			                    }
		                    }
	                    ]
                    });
                    $( "#dialogMusique1" ).dialog( "open" );
                    // event.preventDefault();
                
                });
                //supression multiple
                $("#DeleteMusique").on("click",function(){
                     var liste={};
                        var i=0;
                        dt.forEach(element=>{
                            if(h[element.Lien]==1){
                                liste[i]=element.Lien;
                                i++;
                            }
                        });
                        console.log(liste);
                    $( "#dialogMusique1" ).dialog({
	                        autoOpen: false,
	                        width: 300,
	                        buttons: [
		                        {
			                        text: "Ok",
			                        click: function() {
				                        $( this ).dialog( "close" );
                                        //alert(liste[1]);
                                        $.ajax({
                                        type: "POST",
                                        url: "default.aspx/DeleteMusique",
                                        data:"{'listemusique':'"+JSON.stringify(liste)+"'}",
                                        contentType: "application/json;charset=utf-8",
                                        dataType: 'json',
                                        success: function (data) {
                                            //alert(data.d);
                                            if(data.d)
                                                RefreshMusique();
                                        },
                                        });
			                        }
		                        },
		                        {
			                        text: "Cancel",
			                        click: function() {
				                        $( this ).dialog( "close" );
			                        }
		                        }
	                        ]
                        });
                        $( "#dialogMusique1" ).dialog( "open" );
                });
            $("#DownloadMusique").on("click",function(){
                var DownAll=$("#DownAllMusique")
                dt.forEach(element=>{
                    if(h[element.Lien]==1){
                        DownAll.attr("href","Zarao_Dossier/Musiques/"+element.Lien);
                        DownAll.get(0).click();
                    }
                });
            });
             $("#UploadMusique").on("click",function(){
       
            $("#inputMusique").get(0).click(); 
           
                 });
             $("#inputMusique").change(function(){
            var files=$(this).get(0).files;   
           var formdata1 =new FormData(); 
                    formdata1.append('musique',files[0]);
               // alert(files[0].name);
                $("#progress").css("display","block");
                $("#progress #nomFichier").text(files[0].name);
                $.ajax({
                    url: "default.aspx",
                    type:"POST",
                    data:formdata1,
                    processData:false,
                    contentType:false,   
                    enctype:'multipart/form-data',  
                    xhr:function(){
                        var xhr=new window.XMLHttpRequest();
                        xhr.upload.addEventListener("progress",function(evt){
                            if(evt.lengthComputable){
                                var percent=(evt.loaded/evt.total)*100;
                                console.log(percent);
                                $("#progress #pourcentage").text(percent.toFixed(1)+"%");
                            }
                        },false);
                        return xhr;
                    },
                    success:function(res){
                    $("#progress").css("display","none");
                       RefreshMusique();
                        alert("Musique uploadé");
                    }
                });  
                //alert("eeee");
            });
        },
    });
}
GetMusique();
$("#DownloadMusique").addClass("disabled");
$("#DeleteMusique").addClass("disabled");
$("#choix-tout").on("click",function(){
    //alert($(this).prop("checked"));
    //$(this).prop("checked",false);
});
$("#RefreshMusique").on("click",function(){
 RefreshMusique();
});
function RefreshMusique(){
    $("#liste-musique").html("");
    GetMusique();
}