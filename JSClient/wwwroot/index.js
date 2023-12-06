const menu = document.getElementById("menu");


function linker(id) {
    switch (true) {
        case id == 'artists':
            window.location.href = "./Artist.html";
            break;
        case id == 'albums':
            window.location.href = "./Album.html";
            break;
        case id == 'songs':
            window.location.href = "./Song.html";
            break;
        case id == 'labels':
            window.location.href = "./Label.html";
            break;
        case id == 'noncruds':
            window.location.href = "./NonCRUD.html";
            break;
        case id == 'menu':
            window.location.href = "./index.html";
            break;
        default:
            break;
    }
}