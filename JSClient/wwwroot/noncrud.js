let artistwithmostsongsatlabelcoll = [];
let albumswithmostsongscoll = [];
let artistsbygenrecoll = [];
let songsbylabelcoll = [];
let labelswithmostalbumscoll = [];
artistwithmostsongsatlabelfunc();
albumswithmostsongfunc();
artistsbygenrefunc();
songsbylabelfunc();
labelswithmostalbumsfunc();

async function artistwithmostsongsatlabelfunc() {
    let id = document.getElementById('LabelId').value;
    await fetch('http://localhost:5124/NC/GetArtistWithMostSongsAtLabel/' + id)
        .then(x => x.json())
        .then(y => {
            artistwithmostsongsatlabelcoll = y;
            console.log(artistwithmostsongsatlabelcoll);
            dispartistwithmostsongsatlabel(id);
        });
}

function dispartistwithmostsongsatlabel(id) {
    document.getElementById('artistWithMostSongsAtLabel').innerHTML = "";
    artistwithmostsongsatlabelcoll.forEach(t => {
        document.getElementById('artistWithMostSongsAtLabel').innerHTML += "<tr><td>" + t.artist.stageName + "</td><td>" + t.songCount + "</td></tr>";
    });
}
async function albumswithmostsongfunc() {
    await fetch('http://localhost:5124/NC/GetAlbumsWithMostSongs/')
        .then(x => x.json())
        .then(y => {
            albumswithmostsongscoll = y;
            console.log(albumswithmostsongscoll);
            dispalbumswithmostsongs();
        });
}
function dispalbumswithmostsongs() {
    document.getElementById('albumsWithMostSongs').innerHTML = "";
    albumswithmostsongscoll.forEach(t => {
        document.getElementById('albumsWithMostSongs').innerHTML += "<tr><td>" + t.album.albumName + "</td><td>" + t.songCount + "</td></tr>";
    });
}
async function artistsbygenrefunc() {
    let genre = document.getElementById('Genre').value;
    await fetch('http://localhost:5124/NC/GetArtistsByGenre/' + genre)
        .then(x => x.json())
        .then(y => {
            artistsbygenrecoll = y;
            console.log(artistsbygenrecoll);
            dispartistsbygenre(genre);
        });
}

function dispartistsbygenre(genre) {
    document.getElementById('artistsByGenre').innerHTML = "";
    artistsbygenrecoll.forEach(t => {
        document.getElementById('artistsByGenre').innerHTML += "<tr><td>" + t.stageName + "</td><td>" + t.realName + "</td></tr>";
    });
}
async function songsbylabelfunc() {
    let id = document.getElementById('LabelIdforSongs').value;
    await fetch('http://localhost:5124/NC/GetSongsByLabel/' + id)
        .then(x => x.json())
        .then(y => {
            songsbylabelcoll = y;
            console.log(songsbylabelcoll);
            dispsongsbylabel(id);
        });
}

function dispsongsbylabel(id) {
    document.getElementById('songsByLabel').innerHTML = "";
    songsbylabelcoll.forEach(t => {
        document.getElementById('songsByLabel').innerHTML += "<tr><td>" + t.songName + "</td><td>" + t.artist.stageName + "</td></tr>";
    });
}
async function labelswithmostalbumsfunc() {
    await fetch('http://localhost:5124/NC/GetLabelsWithMostAlbums/')
        .then(x => x.json())
        .then(y => {
            labelswithmostalbumscoll = y;
            console.log(labelswithmostalbumscoll);
            displabelswithmostalbums();
        });
}
function displabelswithmostalbums() {
    document.getElementById('labelsWithMostAlbums').innerHTML = "";
    labelswithmostalbumscoll.forEach(t => {
        document.getElementById('labelsWithMostAlbums').innerHTML += "<tr><td>" + t.label.labelName + "</td><td>" + t.albumCount + "</td></tr>";
    });
}