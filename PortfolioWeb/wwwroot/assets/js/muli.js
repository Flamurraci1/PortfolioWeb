let url = 'Contact/GetMyData';
const options = {
    method: 'GET',
    headers: {
        'Content-Type': 'application/json'
    }
}
try {
    let res = fetch(url)
        .then(response => response.json())
        .then(data => {
            document.getElementById('Address').innerHTML = data[0].address;
            document.getElementById('Email').innerHTML = data[0].email;
            document.getElementById('Twitter').innerHTML = data[0].twitter;
            console.log(data[0]);
        }

        );
    ;

} catch (error) {
    console.log(error);
}
