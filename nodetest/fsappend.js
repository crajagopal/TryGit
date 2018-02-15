var fs = require('fs');

 

fs.open('mynewfile1.txt', 'w', function (err, file) {
    if (err) throw err;
    console.log('Saved!');
  });

  fs.writeFile('mynewfile1.txt', 'Hello content!', function (err) {
    if (err) throw err;
    console.log('Saved!');
  });

  fs.appendFile('mynewfile1.txt', ' This is my text.', function (err) {
    if (err) throw err;
    console.log('Updated!');
  });

  
fs.unlink('mynewfile1.txt', function (err) {
    if (err) throw err;
    console.log('File deleted!');
  }); 