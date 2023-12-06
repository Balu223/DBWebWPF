let artists = [];
let connection = null;
let artistIdtoupdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
     connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5124/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ArtistCreated", (user, message) => {
        getdata();
    });
    connection.on("ArtistDeleted", (user, message) => {
        getdata();
    });
    connection.on("ArtistUpdated", (user, message) => {
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
    await fetch('http://localhost:5124/Artist')
        .then(x => x.json())
        .then(y => {
            artists = y;
            //console.log(artists);
            display();
        });
}


function display() {
    document.getElementById('resultarea').innerHTML = "";
    artists.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.artistId + "</td><td>" + t.realName + "</td><td>" + t.stageName + "</td><td>" + t.dateOfBirth + "</td><td>" + `<button type="button" onclick="remove(${t.artistId})">Delete</button>` + `<button type="button" onclick="showupdate(${t.artistId})">Update</button>`+ "</td></tr>";
    });
}

function remove (id)  {
    fetch('http://localhost:5124/Artist/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function showupdate(id) {
    document.getElementById('RealNametoupdate').value = artists.find(t => t['artistId'] == id)['realName'];
    document.getElementById('StageNametoupdate').value = artists.find(t => t['artistId'] == id)['stageName'];
    document.getElementById('DateOfBirthtoupdate').value = artists.find(t => t['artistId'] == id)[Date.parse(('dateOfBirth').substring(0,9))];
    document.getElementById('updateformdiv').style.display = 'flex';
    artistIdtoupdate = id;
}
function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let real = document.getElementById('RealNametoupdate').value;
    let stage = document.getElementById('StageNametoupdate').value;
    let date = document.getElementById('DateOfBirthtoupdate').value;
    fetch('http://localhost:5124/Artist', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { RealName: real, StageName: stage, DateOfBirth: date, artistId: artistIdtoupdate }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let real = document.getElementById('RealName').value;
    let stage = document.getElementById('StageName').value;
    let date = document.getElementById('DateOfBirth').value;
    fetch('http://localhost:5124/Artist', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { RealName: real, StageName: stage, DateOfBirth: date }),})
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}
