import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';

const Footer = () => {
    return (
        <Box component="footer" py={2} bgcolor="background.paper">
            {/* Footer content goes here */}
            <Typography variant="body2" color="text.secondary" align="center">
                My Footer
            </Typography>
        </Box>
    );
};

export default Footer;
