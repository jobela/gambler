import React from 'react';
import logo from './logo.svg';
import './App.css';
import { ScoreBoardTableComponent } from './ScoreBoardTableComponent';

function App() {

  console.log('Scavenger hunt goes brrrr');
  console.log('shorturl.at/nqQT6');

  return (
    <div className="App">
      <h1>Scavenger hunt VFS Tech</h1>

      <p className="center bold">Do you got what it takes to get on the scoreboard?</p>

      <br/>
      <ScoreBoardTableComponent/>
      <br/>

      <h4>Happy scavenger hunt!</h4>

      <div className='hidden'>
        <p>
          Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque mattis viverra accumsan. Duis faucibus sed sem ac porttitor. Sed hendrerit justo ut rutrum consectetur. Nam ultricies tellus elit, in egestas turpis sodales a. Donec ultricies, mauris nec gravida sollicitudin, nisl diam semper ligula, sed tristique nisl urna sed nisl. Pellentesque nec risus tortor. Suspendisse eu tincidunt turpis. Praesent in posuere erat. Etiam eget leo condimentum, volutpat nibh vel, tempor magna. Curabitur hendrerit ultrices urna pretium aliquet. Phasellus iaculis viverra nisi nec egestas. <br /><br />
          Quisque pharetra dapibus nisi non congue. Nam libero justo, tristique in justo vel, finibus condimentum quam. Fusce eu mi augue. Phasellus aliquam tincidunt lorem, a semper ante scelerisque et. Curabitur non mi ut elit sodales varius sit amet et odio. Etiam bibendum, purus vel tincidunt hendrerit, nunc nibh condimentum velit, id imperdiet ex quam non lacus. Cras sed est ex. In a condimentum ante. <br /><br />
          aHR0cHM6Ly9kb2NzLmdvb2dsZS5jb20vZG9jdW1lbnQvZC8xZUpHdW9GVzJDY1R5Y3NKYkJnZkxfZ1U3SmtTYlhvYnJBSDU3dDJwVDhQcy9lZGl0P3VzcD1zaGFyaW5n <br /><br />
          Morbi elementum quam neque, vel scelerisque lacus placerat id. Nulla fermentum ex ex, in volutpat libero cursus id. Maecenas pretium eleifend blandit. Duis accumsan velit laoreet, congue libero at, maximus tellus. Vivamus porttitor tortor sed lacinia iaculis. Duis sit amet maximus diam. Sed eget convallis quam, in viverra magna. Vestibulum ac orci magna. Donec non sagittis lacus. Fusce eget ligula pellentesque, lobortis nunc vel, rhoncus dolor. Interdum et malesuada fames ac ante ipsum primis in faucibus. Sed erat dolor, fermentum at lacinia at, congue ac arcu. Aliquam eget neque eros. <br /><br />
          Maecenas sed ultricies elit. Phasellus lobortis massa quis arcu convallis venenatis. Vestibulum augue tortor, venenatis eu dictum ac, facilisis in nunc. Maecenas nec efficitur orci. Suspendisse blandit tortor ut diam ultricies porttitor. Nulla sodales sapien vel elit fringilla, vel iaculis libero interdum. Nunc non accumsan nisl, in faucibus libero. Nullam id augue nec urna auctor scelerisque a ut sem. Suspendisse vitae mollis lacus. Fusce fermentum nisi turpis, eu gravida odio volutpat a. Aenean lacinia purus ut tristique efficitur. Morbi eu sollicitudin ex. Aenean a lobortis mi, ac sodales tellus. Nunc tincidunt rhoncus augue, ac consectetur diam porta quis. <br /><br />
          Donec varius augue sollicitudin est scelerisque fringilla. Quisque id mauris odio. Nulla ornare, sapien a fringilla convallis, ipsum metus molestie lorem, ac feugiat lorem odio sed dui. Aliquam erat volutpat. Curabitur ultrices sem non elit tempus tempus. Vestibulum hendrerit, dui eu rutrum maximus, magna ex rhoncus augue, id sodales erat magna sit amet enim. Proin vel ipsum id augue aliquet feugiat vitae quis neque. Nullam consectetur magna et dui accumsan imperdiet. Aliquam erat volutpat. <br />
        </p>      
      </div>
      
    </div>
  );
}

export default App;
