let labels = [];
let connection = null;
let labelIdtoupdate = -1;
getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:5124/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("LabelCreated", (user, message) => {
        getdata();
    });
    connection.on("LabelDeleted", (user, message) => {
        getdata();
    });
    connection.on("LabelUpdated", (user, message) => {
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
    await fetch('http://localhost:5124/Label')
        .then(x => x.json())
        .then(y => {
            labels = y;
            //console.log(artists);
            display();
        });
}


function display() {
    document.getElementById('resultarea').innerHTML = "";
    labels.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.labelId + "</td><td>" + t.labelName + "</td><td>" + t.address + "</td><td>" + `<button type="button" onclick="remove(${t.labelId})">Delete</button>` + `<button type="button" onclick="showupdate(${t.labelId})">Update</button>` + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:5124/Label/' + id, {
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
    document.getElementById('LabelNametoupdate').value = labels.find(t => t['labelId'] == id)['labelName'];
    document.getElementById('Addresstoupdate').value = labels.find(t => t['labelId'] == id)[('address')];
    document.getElementById('updateformdiv').style.display = 'flex';
    labelIdtoupdate = id;
}
function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('LabelNametoupdate').value;
    let address = document.getElementById('Addresstoupdate').value;
    fetch('http://localhost:5124/Label', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { LabelName: name, Address: address, labelId: labelIdtoupdate }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let name = document.getElementById('LabelName').value;
    let address = document.getElementById('Address').value;
    fetch('http://localhost:5124/Label', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { LabelName: name, Address: address }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}
