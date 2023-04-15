import Container from '@mui/material/Container';
import Typography from '@mui/material/Typography';

const Login = () => {
    return (
        <Container component="main" sx={{ flexGrow: 1, mt: 2 }}>
            {/* Body content goes here */}
            <Typography variant="h4" component="h1" align="center">
                Body Content
            </Typography>
        </Container>
    );
};

export default Login;
