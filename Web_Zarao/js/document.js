function GetDocument() { 
    $.ajax({
        type: 'POST',
        url: "default.aspx/GetDocument",
        contentType: "application/json;charset=utf-8",
        dataType: 'json',
        success: function (data) { 
            var dt=JSON.parse(data.d);
             $("#NumDocument").text(dt.length);
           // console.log(dt);
           var h={};
            var num=0;
            dt.forEach(document=>{
                $("#liste-document").append(" <ul><li><input type='checkbox' class='filled-in red choix-document' id='document"+num+"' name='"+document.Titre+"' /><label for='document"+num+"'></label></li> <li><span><img src='IconDocument\\"+document.Icon+"'/>"+document.Titre+"</span></li><li > <div ><a href='Zarao_Dossier/Documents/"+document.Titre+"' download> <i class='material-icons '>file_download</i></a><i class='material-icons DeleteDocument' name='"+document.Titre+"'>delete</i> </div> </li><li><span>"+document.Taille+"</span></li><li><span>"+document.DateModif+"</span></li> </ul>");
                h[document.Titre]=0;
                num++;
            }); 
            console.log("eto");
             for(var x=0;x<dt.length;x++){
                 $("#document"+x).prop("checked",false);
                }

             $(".choix-document").on("click",function(){
                if($(this).prop("checked")){
                    h[$(this).attr("name")]=1;
                }else{
                    h[$(this).attr("name")]=0;
                }
                var i=0;
                dt.forEach(item=>{
                    if(h[item.Titre]==1)
                        i++;
                });
                if(i>0){
                    $("#DownloadDocument").removeClass("disabled");
                    $("#DeleteDocument").removeClass("disabled");
                }
                else{
                    $("#DownloadDocument").addClass("disabled");
                    $("#DeleteDocument").addClass("disabled");
                }
                //alert($(this).attr("id"));  
            });
            $("#DownloadDocument").on("click",function(){
                var DownAll=$("#DownAllDocument")
                dt.forEach(element=>{
                    if(h[element.Titre]==1){
                        DownAll.attr("href","Zarao_Dossier/Documents/"+element.Titre);
                        DownAll.get(0).click();
                    }
                });
            });

            $("#DeleteDocument").on("click",function(){
                var liste={};
                        var i=0;
                        dt.forEach(element=>{
                            if(h[element.Titre]==1){
                                liste[i]=element.Titre;
                                i++;
                            }
                        });
                        console.log(liste);
                    $( "#dialogDocument1" ).dialog({
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
                                        url: "default.aspx/DeleteDocument",
                                        data:"{'listedocument':'"+JSON.stringify(liste)+"'}",
                                        contentType: "application/json;charset=utf-8",
                                        dataType: 'json',
                                        success: function (data) {
                                            //alert(data.d);
                                            if(data.d)
                                                RefreshDocument();
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
                        $( "#dialogDocument1" ).dialog( "open" );
            });
            $(".DeleteDocument").on("click",function(){
                 var nom=$(this).attr("name");
                        $( "#dialogDocument1" ).dialog({
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
                                        url: "default.aspx/DeleteDocumentSolo",
                                        data:"{'document':'"+nom+"'}",
                                        contentType: "application/json;charset=utf-8",
                                        dataType: 'json',
                                        success: function (data) {
                                            //alert(data.d);
                                            if(data.d)
                                                RefreshDocument();
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
                    $( "#dialogDocument1" ).dialog( "open" );
                    // event.preventDefault();
            });
             $("#UploadDocument").on("click",function(){
                 $("#inputDocument").get(0).click(); 
              });
                $("#inputDocument").change(function(){
            var files=$(this).get(0).files;   
           var formdata1 =new FormData(); 
                    formdata1.append('document',files[0]);
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
                       RefreshDocument();
                        alert("Musique uploadé");
                    }
                });  
                //alert("eeee");
            });
        },
    });
}
GetDocument();
function RefreshDocument(){
    $("#liste-document").text("");
    GetDocument();
}
$("#DownloadDocument").addClass("disabled");
$("#DeleteDocument").addClass("disabled");
$("#RefreshDocument").on("click",function(){
    RefreshDocument();
});