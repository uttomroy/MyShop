import { Button, Stack, Typography } from '@mui/material';
import AppBar from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import SchoolIcon from '@mui/icons-material/School';

const Header = () => {
    return (
        <AppBar position="static" sx={{ backgroundColor: 'white' }} >
            <Toolbar>
                <SchoolIcon color='primary' />
                <Typography sx={{color: '#1976d2'}} ml={2}>
                    Management System
                </Typography>
                <Stack direction={'row'} sx={{marginLeft: 'auto'}} spacing={2}>
                    <Button variant="contained" >Login</Button>
                    <Button variant="contained" >Signup</Button>
                </Stack>

            </Toolbar>
        </AppBar>
    );
};

export default Header;
