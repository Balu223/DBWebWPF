let songs = [];
let connection = null;
let songIdtoupdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5124/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("SongCreated", (user, message) => {
        getdata();
    });
    connection.on("SongDeleted", (user, message) => {
        getdata();
    });
    connection.on("SongUpdated", (user, message) => {
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
    await fetch('http://localhost:5124/Song')
        .then(x => x.json())
        .then(y => {
            songs = y;
            //console.log(artists);
            display();
        });
}


function display() {
    document.getElementById('resultarea').innerHTML = "";
    songs.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.songId + "</td><td>" + t.songName + "</td><td>" + t.genre + "</td><td>" + `<button type="button" onclick="remove(${t.songId})">Delete</button>` + `<button type="button" onclick="showupdate(${t.songId})">Update</button>` + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:5124/Song/' + id, {
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
    document.getElementById('SongNametoupdate').value = songs.find(t => t['songId'] == id)['songName'];
    document.getElementById('Genretoupdate').value = songs.find(t => t['songId'] == id)[('genre')];
    document.getElementById('updateformdiv').style.display = 'flex';
    songIdtoupdate = id;
}
function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('SongNametoupdate').value;
    let genre = document.getElementById('Genretoupdate').value;
    fetch('http://localhost:5124/Song', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { SongName: name, Genre: genre, songId: songIdtoupdate }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let name = document.getElementById('SongName').value;
    let genre = document.getElementById('Genre').value;
    fetch('http://localhost:5124/Song', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { SongName: name, Genre: genre}),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}
