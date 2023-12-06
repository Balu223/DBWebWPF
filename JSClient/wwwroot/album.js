let albums = [];
let connection = null;
let albumIdtoupdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5124/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("AlbumCreated", (user, message) => {
        getdata();
    });
    connection.on("AlbumDeleted", (user, message) => {
        getdata();
    });
    connection.on("AlbumUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}


async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};
async function getdata() {
    await fetch('http://localhost:5124/Album')
        .then(x => x.json())
        .then(y => {
            albums = y;
            //console.log(artists);
            display();
        });
}


function display() {
    document.getElementById('resultarea').innerHTML = "";
    albums.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.albumId + "</td><td>" + t.albumName + "</td><td>" + t.releaseDate + "</td><td>" + `<button type="button" onclick="remove(${t.albumId})">Delete</button>` + `<button type="button" onclick="showupdate(${t.albumId})">Update</button>` + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:5124/Album/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function showupdate(id) {
    document.getElementById('AlbumNametoupdate').value = albums.find(t => t['albumId'] == id)['albumName'];
    document.getElementById('ReleaseDatetoupdate').value = albums.find(t => t['albumId'] == id)[Date.parse(('releaseDate').substring(0, 9))];
    document.getElementById('updateformdiv').style.display = 'flex';
    albumIdtoupdate = id;
}
function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('AlbumNametoupdate').value;
    let date = document.getElementById('ReleaseDatetoupdate').value;
    fetch('http://localhost:5124/Album', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { AlbumName: name, ReleaseDate: date, albumId: albumIdtoupdate }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let name = document.getElementById('AlbumName').value;
    let date = document.getElementById('ReleaseDate').value;
    fetch('http://localhost:5124/Album', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { AlbumName: name, ReleaseDate: date }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}
