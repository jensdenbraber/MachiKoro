from setuptools import setup


def readme():
    """Reads the 'READMD.md' file

    Returns:
        string: 'README.md' file content
    """
    with open('README.md') as file:
        return file.read()


setup(
    name='MachiKoro',
    version='0.0.1',
    author='Jens den Braber',
    author_email='',
    packages=['machi_koro.core'],
    python_requires='>=3.8',
    #scripts=['bin/script1', 'bin/script2'],
    license='LICENSE.txt',
    description='An awesome package that does something',
    long_description=readme(),
    long_description_content_type='text/markdown',
    install_requires=[],
    tests_require=['pytest'],
    entry_points={'console_scripts': [
        ''
    ]}
)
