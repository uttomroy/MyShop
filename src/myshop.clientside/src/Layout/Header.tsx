import { Button, Stack, Typography } from '@mui/material';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import SchoolIcon from '@mui/icons-material/School';

const Header = () => {
    return (
        <AppBar position="static" sx={{ background: '#063970' }} >
            <Toolbar>
                <SchoolIcon />
                <Typography ml={2}>
                    Management System
                </Typography>
                <Stack direction={'row'} sx={{marginLeft: 'auto'}} spacing={2}>
                    <Button href='/Login' variant="contained" >Login</Button>
                    <Button variant="contained" >Signup</Button>
                </Stack>

            </Toolbar>
        </AppBar>
    );
};

export default Header;
