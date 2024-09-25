const firebaseConfig = {
    apiKey: "AIzaSyDQ8UNfWKTJrsyZVtNPCpDSWhgDZtAjSHA",
    authDomain: "netmvc-9b582.firebaseapp.com",
    projectId: "netmvc-9b582",
    storageBucket: "netmvc-9b582.appspot.com",
    messagingSenderId: "376810587274",
    appId: "1:376810587274:web:a6d3da5374ef26a24b9973",
    measurementId: "G-Q0FY9KWZEC"
};

// Initialize Firebase
firebase.initializeApp(firebaseConfig);

function chooseFile(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#image').attr('src', e.target.result);
            imgError.textContent = '';
        };
        reader.readAsDataURL(input.files[0]);
    }
}

function uploadImage(folder) {
    const ref = firebase.storage().ref(folder + '/');
    const file = document.querySelector('#photo').files[0];
    const metadata = {
        contentType: file.type
    };
    const name = Date.now() + "-" + file.name; // Unique file name
    const uploadIMG = ref.child(name).put(file, metadata);

    uploadIMG.then(snapshot => snapshot.ref.getDownloadURL())
        .then((url) => {
            if (url) {
                document.getElementById('ProductImageUrl').value = url;
            }
        })
        .catch((error) => {
            console.error("Error uploading image: ", error);
        });
}
