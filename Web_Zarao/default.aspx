<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web_Zarao.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="Stylesheet" type="text/css" href="css/default.css" />
<link rel="Stylesheet" type="text/css" href="css/image.css" />
<link rel="Stylesheet" type="text/css" href="css/video.css" />
<link rel="Stylesheet" type="text/css" href="css/musique.css" />
<link rel="Stylesheet" type="text/css" href="css/document.css" />
<link rel="Stylesheet" type="text/css" href="css/chat.css" />
<link rel="Stylesheet" type="text/css" href="css/logiciel.css" />
<link rel="Stylesheet" type="text/css" href="css/dossier.css" />
</asp:Content>
<asp:Content ID="Content2"  ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-page">
        
        <!--Default-->
      
        <div id="default">
            <hr id="ligne"/>
            <div id="serveur">
                <span id="nom-pc">SERVEUR : <% Response.Write(Environment.MachineName);%></span>
                <span id="sys-pc"><%=this.getWinInfo() %></span>
            </div>
            <img src="img/ordi2.png" id="img_ordi"/>
            <table id="table">
                <tr>
                    <td><center><a class="btn btn-floating  btn-pulse b1 tooltipped"   data-position="top" data-delay="50" data-tooltip="Photos"><i class="material-icons icone" >photo</i></a><br /><span class="num" id="NumImage">0</span></center></td>
                    <td><center><a class="btn btn-floating  btn-pulse b2 tooltipped"  data-position="top" data-delay="50" data-tooltip="Vidéos"><i class="material-icons" >movie</i></a><br /><span class="num " id="NumVideo">0</span></center></td>
                    <td><center><a class="btn btn-floating  btn-pulse b3 tooltipped"  data-position="top" data-delay="50" data-tooltip="Musiques"><i class="material-icons">music_note</i></a><br /><span class="num" id="NumMusique">0</span></center></td>
                    <td><center><a class="btn btn-floating  btn-pulse b4 tooltipped"  data-position="top" data-delay="50" data-tooltip="Documents"><i class="material-icons">description</i></a><br /><span class="num" id="NumDocument">0</span></center></td>
                </tr>
                <tr>
                    <td></td>
                    <td><center><a class="btn btn-floating  btn-pulse b5 tooltipped"  data-position="bottom" data-delay="50" data-tooltip="Chat"><i class="material-icons">chat</i></a></center></td>
                    <td><center><a class="btn btn-floating  btn-pulse b6 tooltipped"  data-position="bottom" data-delay="50" data-tooltip="Logiciels"><i class="material-icons">widgets</i></a></center></td>
                    <td><center><a class="btn btn-floating  btn-pulse b7 tooltipped"  data-position="bottom" data-delay="50" data-tooltip="Fichiers"><i class="material-icons">folder_open</i></a></center></td>
                </tr>
            </table>
        </div>
        <!---->
        <!--Image-->
        <div id="image">
                <a class="waves-effect waves-light btn red tete btn-tete " id="UploadImage"><i class="material-icons right">file_upload</i>Ajouter Image<input id="inputImage" name="image" type="file" accept="image/*" style="display:none;" multiple /></a>
                <a class="btn-floating btn waves-effect waves-light light-blue tete " id="DownloadImage"><i class="material-icons">file_download</i></a>
                <a class="btn-floating btn waves-effect waves-light orange tete " id="DeleteImage" ><i class="material-icons">delete</i></a>
                <a class="btn-floating btn waves-effect waves-light green accent-4 tete"  id="RefreshImage" ><i class="material-icons">refresh</i></a>
                <a id="DownAllImage" href="" onclick="console.log('telechargement lancé');" download></a>
                <hr id="ligne"/>
                <center><span class="titre-contenu">Gallerie</span></center>
                <hr class="ligne"/>
                <div id="en-tete">
                    <input type="checkbox" class="filled-in #673ab7 deep-purple" id="box-all" checked="unchecked"/><label for="box-all"></label>
                    <span>Mes images</span>
                </div>
                <div id="boite-image" class="scroll-milay1">
                    <!--div class="image-div">
                        <img src="img/iron.jpg" class="image"   />
                        <div class="choix"><i class="material-icons ">check</i></div> 
                        <div class="controle"> 
                            <i class="material-icons">file_download</i>
                            <i class="material-icons">delete</i>
                        </div>
                    </div>
                    <div class="image-div">
                        <img src="img/fond.jpg" class="image"  />
                        <div class="choix"><i class="material-icons ">check</i></div> 
                        <div class="controle"> 
                            <i class="material-icons">file_download</i>
                            <i class="material-icons">delete</i>
                        </div>
                    </div-->
                    
                 </div>
                <div id="modal-image">
                    <center><img src="" /></center> 
                </div>
                <div id="dialogImage1" title="Suppression des images">
	                <p>Supprimer les images sélectionnées?</p>
                </div>
        </div>
        <!---->
        <!--Video-->
        <div id="video">
            <a class="waves-effect waves-light btn light-blue tete btn-tete" id="UploadVideo" ><i class="material-icons right">file_upload</i>Ajouter vidéo<input id="inputVideo" name="video" type="file" accept="video/*" style="display:none;" multiple /></a>
            <a class="btn-floating btn waves-effect waves-light red tete" id="DownloadVideo"><i class="material-icons">file_download</i></a>
            <a class="btn-floating btn waves-effect waves-light orange tete" id="DeleteVideo"><i class="material-icons">delete</i></a>
            <a class="btn-floating btn waves-effect waves-light green tete" id="RefreshVideo"><i class="material-icons">refresh</i></a>
             <a id="DownAllVideo" href="" onclick="console.log('telechargement lancé');" download></a>
            <hr id="ligne"/>
            <center><span class="titre-contenu">Vidéos</span></center>
            <hr class="ligne"/>
            <div id="en-tete">
                <input type="checkbox" class="filled-in #673ab7 deep-purple" id="box-all" checked="unchecked"/><label for="box-all"></label>
                <span>Tout sélectionner</span>
            </div>
            <div id="boite-video" class="scroll-milay2">
                <!--div class="video-div">
                    <div class="controle"> 
                        <i class="material-icons">check</i>
                        <i class="material-icons">file_download</i>
                        <i class="material-icons">delete</i>
                    </div>
                    <video class="responsive-video"  controls>
                        <source src="img/naruto.mp4" type="video/mp4">
                    </video>
                </div>
                <div class="video-div">
                    <div class="controle"> 
                        <i class="material-icons ">check</i>
                        <i class="material-icons">file_download</i>
                        <i class="material-icons">delete</i>
                    </div>
                    <video class="responsive-video"  controls>
                        <source src="img/naruto.mp4" type="video/mp4">
                    </video>
                </div-->
            </div>
            <div id="dialogVideo1" title="Suppression des videos">
	                <p>Supprimer les videos sélectionnées?</p>
                </div>
        </div>
        <!---->
        <!--Musique-->
        <div id="musique">
            <a class="waves-effect waves-light btn orange tete btn-tete" id="UploadMusique"><i class="material-icons right">file_upload</i>Ajouter musique<input id="inputMusique" name="musique" type="file" accept="audio/*" style="display:none;" multiple /></a>
            <a class="btn-floating btn waves-effect waves-light red tete" id="DownloadMusique" ><i class="material-icons">file_download</i></a>
            <a class="btn-floating btn waves-effect waves-light blue tete" id="DeleteMusique" ><i class="material-icons">delete</i></a>
            <a class="btn-floating btn waves-effect waves-light green tete" id="RefreshMusique" ><i class="material-icons">refresh</i></a>
            <a id="DownAllMusique" href="" onclick="console.log('telechargement lancé');" download></a>
            <hr id="ligne"/>
            <center><span class="titre-contenu">Musique</span></center>
            <hr class="ligne"/>
            <div id="table-musique">
                <div id="en-tete">
                    <ol>
                        <li ><input type="checkbox" class="filled-in red" id="choix-tout-musique"  /><label for="choix-tout-musique"></label></li>
                        <li ><span >Titre</span></li>
                        <li ><div ></div></li>
                        <li ><span >Artiste</span></li>
                        <li ><span >Durée</span></li>
                        <li ><span >Format</span></li>
                        <li ><span >Taille</span></li>
                    </ol>
                </div>
                <!--repetition-->
                <div id="liste-musique" class="scroll-milay3">
                    <!--ul >
                        <li ><input type="checkbox" class="filled-in red" id="filled-in-bo" checked="checked"/><label for="filled-in-bo"></label></li>
                        <li><span>Up&up</span></li>
                        <li >
                            <div >
                                <i class="material-icons">play_arrow</i>
                                <i class="material-icons">file_download</i>
                                <i class="material-icons">delete</i>
                            </div>
                        </li>
                        <li><span>unknow</span></li>
                        <li><span>03:52</span></li>
                        <li><span>mp3</span></li>
                        <li><span>3.6mb</span></li>
                    </ul-->
                    
                </div>
            </div>
            <div id="controle-musique">
                <div id="track">
                    <i class="material-icons">music_note</i>
                    <span id="title-track">Non defini</span><br />
                    <span id="artiste-track">inconnu </span>
                    <img src="img/spectre.gif"/>
                </div>
                <div id="control-panel">
                    <div id="prev-next">
                        <i class="material-icons" id="prev-track">skip_previous</i>
                        <i class="material-icons" id="next-track">skip_next</i>
                    </div>
                    <div id="audio">
                        <audio  src="other/test.mp3"  controls></audio>
                    </div>
                </div>           
            </div>
             <div id="dialogMusique1" title="Suppression des musiques">
	                <p>Supprimer les musiques sélectionnées?</p>
                </div>
        </div>
        <!---->
        <!--Document-->
        <div id="document">
            <a class="waves-effect waves-light btn green accent-4 tete btn-tete" id="UploadDocument"><i class="material-icons right">file_upload</i>Ajouter document<input id="inputDocument" name="document" type="file" accept=".pdf,.doc,.docx,.pptx.,.txt,.xls,.ppt,.xlsx" style="display:none;" multiple /></a>
            <a class="btn-floating btn waves-effect waves-light red tete" id="DownloadDocument" ><i class="material-icons">file_download</i></a>
            <a class="btn-floating btn waves-effect waves-light blue tete" id="DeleteDocument" ><i class="material-icons">delete</i></a>
            <a class="btn-floating btn waves-effect waves-light green tete" id="RefreshDocument" ><i class="material-icons">refresh</i></a>
            <a id="DownAllDocument" href="" onclick="console.log('telechargement lancé');" download></a>
            <hr id="ligne"/>
            <center><span class="titre-contenu">Documents</span></center>
            <hr class="ligne"/>
            <div id="table-document">
                <div id="en-tete">
                    <ol>
                        <li ><input type="checkbox" class="filled-in #673ab7 deep-purple" id="choix-tout-document" /><label for="choix-tout-document"></label></li>
                        <li ><span >Nom</span></li>
                        <li ><div ></div></li>
                        <li ><span >Taille</span></li>
                        <li ><span >Dernière modification</span></li>
                    </ol>
                </div>
                <!--repetition-->
                <div id="liste-document" class="scroll-milay4">
                    <!--ul >
                        <li ><input type="checkbox" class="filled-in red" id="filled-in-bo" checked="checked"/><label for="filled-in-bo"></label></li>
                        <li><span><img src="test.png"/>Up&up</span></li>
                        <li >
                            <div >
                                <i class="material-icons">file_download</i>
                                <i class="material-icons">delete</i>
                            </div>
                        </li>
                        <li><span>unknow</span></li>
                        <li><span>03:52</span></li>
                    </ul-->
                </div>
            </div>    
            <div id="dialogDocument1" title="Suppression des documents">
	                <p>Supprimer les documents sélectionnées?</p>
                </div>
        </div>
        <!---->
        <!--Chat-->
        <div id="chat">
            <hr id="ligne"/>
            <div id="boite1" class="scroll-milay5">
                <ul id="boite-message">    
                    <!--li class="boite-message">
                        <img src="img/avatar1.png" alt="" class="circle autre">
                        <span class="nom-autre">Miantsa</span>
                    <span class="msg-autre"> sdgggggggggg ggggggggggggggg<br /> gggggggggggggggg<br /> gggggggggggggggggg</span>
                    </li>
                    <li class="boite-message">
                        <img src="img/avatar1.png" alt="" class="circle moi">
                    <span class="msg-moi"> sdggggggggggggggggggggggggg gggggggggggggggggggggggggggggggggg</span>
                    </li>
                    <li class="boite-message">
                        <img src="img/avatar1.png" alt="" class="circle moi">
                    <span class="msg-moi "> sdggggggggggggggggggggggggg gggggggggggggggggggggggggggggggggg</span>
                    </li>
                    <li class="boite-message">
                        <img src="img/avatar1.png" alt="" class="circle autre">
                        <span class="nom-autre">Miantsa</span>
                    <span class="msg-autre"> sdgggggggggg ggggggggggggggg<br /> gggggggggggggggg<br /> gggggggggggggggggg</span>
                    </li>
                    <li class="boite-message">
                        <img src="img/avatar1.png" alt="" class="circle moi">
                    <span class="msg-moi"> sdggggggggggggggggggggggggg gggggggggggggggggggggggggggggggggg</span>
                    </li>
                     </li>
                    <li class="boite-message">
                        <img src="img/avatar1.png" alt="" class="circle moi">
                    <span class="msg-moi"> sdggggggggggggggggggggggggg gggggggggggggggggggggggggggggggggg</span>
                    </li>
                     </li>
                    <li class="boite-message">
                        <img src="img/avatar1.png" alt="" class="circle moi">
                    <span class="msg-moi"> sdggggggggggggggggggggggggg gggggggggggggggggggggggggggggggggg</span>
                    </li-->
                    
                </ul>
                
            </div>
            <div id="boite2">
                        <div class="input-field " id="input-message">
                            <textarea id="message" class=""></textarea>
                            <label for="message">Votre message</label>
                        </div>
                <a class="btn-floating btn-large waves-effect waves-light red"  id="btn-envoie"><i class="material-icons">send</i></a>
                <a href="#fin" id="fin-lien"></a>
            </div>
        </div>
        <!---->
        <!--Logiciel-->
        <div id="logiciel">
            <a class="waves-effect waves-light btn pink accent-4 tete btn-tete" id="UploadLogiciel"><i class="material-icons right">file_upload</i>Ajouter logiciel<input id="inputLogiciel" name="logiciel" type="file" accept=".exe,.msi,.zip,.rar" style="display:none;" multiple /></a>
            <a class="btn-floating btn waves-effect waves-light red tete" id="DownloadLogiciel" ><i class="material-icons">file_download</i></a>
            <a class="btn-floating btn waves-effect waves-light green tete" id="RefreshLogiciel"><i class="material-icons">refresh</i></a>
            <a id="DownAllLogiciel" href="" onclick="console.log('telechargement lancé');" download></a>
            <hr id="ligne"/>
            <center><span class="titre-contenu">Logiciels</span></center>
            <hr class="ligne" />
            <div id="boite-logiciel" class="scroll-milay6">
                <!--div class="logiciel-div">
                    <img src="img/iron.jpg" class="image"  />
                        <span class="log-name">Arduino sdsd gsdgdgdhfd fdhdfh</span><br />
                        <span class="log-size">21.3 Mo</span>
                        <div class="choix"><i class="material-icons ">check</i></div> 
                    <div class="controle"> 
                        <i class="material-icons">file_download</i>
                        <i class="material-icons">delete</i>
                    </div>
                </div-->
                
            </div>
            <div id="dialogLogiciel1" title="Suppression des logiciels">
	                <p>Supprimer les logiciels sélectionnées?</p>
                </div>
        </div>
        <!---->
        <!--Dossier-->
        <div id="dossier">
            <a class="waves-effect waves-light btn purple accent-4 tete btn-tete" id="UploadAutre"><i class="material-icons right">file_upload</i>Ajouter fichier<input id="inputAutre" name="autre" type="file"  style="display:none;" multiple /></a>
            <a class="btn-floating btn waves-effect waves-light red tete" id="DownloadAutre"><i class="material-icons">file_download</i></a>
            <a class="btn-floating btn waves-effect waves-light green tete" id="RefreshAutre"><i class="material-icons">refresh</i></a>
            <a id="DownAllDossier" href="" onclick="console.log('telechargement lancé');" download></a>
            <hr id="ligne"/>
            <center><span class="titre-contenu">Autres Fichier</span></center>
            <hr class="ligne" />
            
          <div id="table-dossier">
                <div id="en-tete">
                    <ol>
                        <li ><input type="checkbox" class="filled-in #673ab7 deep-purple" id="choix-tout-dossier" /><label for="choix-tout-dossier"></label></li>
                        <li ><span >Nom</span></li>
                        <li ><div ></div></li>
                        <li ><span >Taille</span></li>
                        <li ><span >Dernière modification</span></li>
                    </ol>
                </div>
                <!--repetition-->
                <div id="liste-dossier" class="scroll-milay7">
                    <!--ul >
                        <li ><input type="checkbox" class="filled-in red" id="filled-in-bo" checked="checked"/><label for="filled-in-bo"></label></li>
                        <li><span><img src="test.png"/>Up&up</span></li>
                        <li >
                            <div >
                                <i class="material-icons">file_download</i>
                                <i class="material-icons">delete</i>
                            </div>
                        </li>
                        <li><span>unknow</span></li>
                        <li><span>03:52</span></li>
                    </ul-->
                </div>
            </div>    
            <div id="dialogDossier1" title="Suppression des documents">
	                <p>Supprimer les documents sélectionnées?</p>
                </div>
        </div>
       
   </div>
</asp:Content>
  