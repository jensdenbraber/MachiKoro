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
    version='0.1.0',
    author='Jens den Braber',
    author_email='',
    packages=['machi_koro.api', 'machi_koro.test'],
    scripts=['bin/script1', 'bin/script2'],
    license='LICENSE.txt',
    description='An awesome package that does something',
    long_description=readme(),
    long_description_content_type='text/markdown',
    install_requires=[
        "unittest"
    ],
)
